using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Base;
using Microsoft.Extensions.Logging;

namespace industry9.Shared.Middleware
{
    public class HistoryMiddleware : Fluxor.Middleware, IDisposable
    {
        private const LogLevel Level = LogLevel.Information;
        private readonly ILogger<HistoryMiddleware> _logger;
        private IStore _store;
        private ISet<string> _restoringState;
        private ISet<string> _stackEnabled;
        private IReadOnlyDictionary<string, LinkedList<object>> _historyStacks;
        private IReadOnlyDictionary<string, IFeature> _historyFeatures;

        public HistoryMiddleware(ILogger<HistoryMiddleware> logger)
        {
            _logger = logger;
        }

        public override Task InitializeAsync(IStore store)
        {
            _store = store;
            InitializeStacks();
            return base.InitializeAsync(store);
        }

        private void InitializeStacks()
        {
            var stacks = new Dictionary<string, LinkedList<object>>();
            _historyFeatures = new ReadOnlyDictionary<string, IFeature>(new Dictionary<string, IFeature>(_store.Features.Where(f => f.Value is IHistoryFeature)));
            foreach (var feature in _historyFeatures.Values)
            {
                stacks.Add(feature.GetName(), new LinkedList<object>());
                feature.StateChanged += FeatureOnStateChanged;
            }
            _historyStacks = new ReadOnlyDictionary<string, LinkedList<object>>(stacks);
            _stackEnabled = new HashSet<string>();
            _restoringState = new HashSet<string>();

            _logger.LogDebug("History tracking enabled for following features: {0}", string.Join(',', _historyFeatures.Keys));
        }

        public override bool MayDispatchAction(object action)
        {
            if (!(action is UndoAction undoAction))
            {
                return true;
            }

            _logger.Log(Level, "Undo action requested for following features: {0}.", string.Join(',', undoAction.Features));
            foreach (var feature in undoAction.Features)
            {
                if (!_historyFeatures.TryGetValue(feature, out var historyFeature) ||
                    !_historyStacks.TryGetValue(feature, out var stack))
                {
                    continue;
                }

                // can't undo initial state
                if (stack.Count < 2)
                {
                    _logger.Log(Level, "{0}: can't undo as feature has its initial state already.", feature);
                    continue;
                }

                // remove newest state as it is no longer valid
                stack.RemoveLast();
                // set previous state without removing it
                _restoringState.Add(feature);
                historyFeature.RestoreState(stack.Last.Value);
                _restoringState.Remove(feature);

                _logger.Log(Level, "{0}: previous state restored with values {1}.", feature, JsonSerializer.Serialize(stack.Last.Value));
                _logger.Log(Level, "{0}: number of tracked states is {1}", feature, stack.Count);
            }

            return false;

        }

        public override void BeforeDispatch(object action)
        {
            if (!(action is IEditAction editAction) || !editAction.Enabled)
            {
                return;
            }

            var features = new HashSet<string>();
            foreach (var feature in editAction.Features)
            {
                if (!_historyFeatures.TryGetValue(feature, out var historyFeature) ||
                    !_historyStacks.TryGetValue(feature, out var stack))
                {
                    continue;
                }

                features.Add(feature);
                // get initial state before any modifications
                stack.AddFirst(historyFeature.GetState());
                // enable storing modified states
                _stackEnabled.Add(feature);
            }

            _logger.Log(Level, "History enabled for following features: {0}", string.Join(',', features));
        }

        public override void AfterDispatch(object action)
        {
            if (!(action is IEditAction editAction) || editAction.Enabled)
            {
                return;
            }

            var features = new HashSet<string>();
            foreach (var feature in editAction.Features)
            {
                if (!_historyFeatures.TryGetValue(feature, out var historyFeature) ||
                    !_historyStacks.TryGetValue(feature, out var stack))
                {
                    continue;
                }

                features.Add(feature);
                if (editAction.SaveChanges)
                {
                    // TODO persist changes via effect
                    //var f = (IHistoryFeature) historyFeature;
                    //f.PersistChanges();
                }
                else
                {
                    // restore state to initial value
                    var initialState = stack.First.Value;
                    historyFeature.RestoreState(initialState);
                }

                stack.Clear();
                _stackEnabled.Remove(feature);
            }

            _logger.Log(Level, "Changes {1} for following features: {0}", string.Join(',', features), editAction.SaveChanges ? "persisted" : "reverted");
        }

        private void FeatureOnStateChanged(object sender, EventArgs e)
        {
            var feature = (IFeature) sender;
            var featureName = feature.GetName();

            // restoring previous state
            if (_restoringState.Contains(featureName))
            {
                return;
            }

            if (!_stackEnabled.Contains(featureName))
            {
                return;
            }

            var state = feature.GetState();
            _historyStacks[featureName].AddLast(state);

            _logger.Log(Level, "{0}: state updated with values {1}", featureName, JsonSerializer.Serialize(state));
            _logger.Log(Level, "{0}: number of tracked states is {1}", featureName, _historyStacks[featureName].Count);
        }

        public void Dispose()
        {
            foreach (var feature in _historyFeatures.Values)
            {
                feature.StateChanged -= FeatureOnStateChanged;
            }
        }
    }
}
