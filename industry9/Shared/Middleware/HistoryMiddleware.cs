using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Base;

namespace industry9.Shared.Middleware
{
    public class HistoryMiddleware : Fluxor.Middleware, IDisposable
    {
        private IStore _store;
        private IReadOnlyDictionary<string, Queue> _historyQueues;
        private ISet<string> _queueEnabled;
        private IReadOnlyDictionary<string, IFeature> _historyFeatures;

        public override Task InitializeAsync(IStore store)
        {
            _store = store;
            InitializeQueues();
            return base.InitializeAsync(store);
        }

        public override bool MayDispatchAction(object action)
        {
            if (!(action is UndoAction undoAction))
            {
                return true;
            }

            foreach (var historyFeature in undoAction.Features)
            {
                if (!_historyFeatures.TryGetValue(historyFeature, out var feature) ||
                    !_historyQueues.TryGetValue(historyFeature, out var queue))
                {
                    continue;
                }

                var prevState = queue.Dequeue();
                feature.RestoreState(prevState);
            }

            return false;

        }

        public override void BeforeDispatch(object action)
        {
            if (action is IEditAction editAction)
            {
                Console.WriteLine($"BEFORE ACTION: {JsonSerializer.Serialize(action)}");
                foreach (var feature in editAction.Features)
                {
                    _queueEnabled.Add(feature);
                }
            }
        }

        public override void AfterDispatch(object action)
        {
            if (action is IEditAction editAction)
            {
                foreach (var feature in editAction.Features)
                {
                    _queueEnabled.Remove(feature);
                }
                Console.WriteLine($"AFTER ACTION: {JsonSerializer.Serialize(action)}");
            }
        }

        private void InitializeQueues()
        {
            var queues = new Dictionary<string, Queue>();
            _historyFeatures = new ReadOnlyDictionary<string, IFeature>(new Dictionary<string, IFeature>(_store.Features.Where(f => f.Value is IHistoryFeature)));
            foreach (var feature in _historyFeatures.Values)
            {
                var historyFeature = (IHistoryFeature) feature;
                queues.Add(feature.GetName(), new Queue(historyFeature.HistoryLength));

                feature.StateChanged += FeatureOnStateChanged;
            }
            _historyQueues = new ReadOnlyDictionary<string, Queue>(queues);
            _queueEnabled = new HashSet<string>();
        }

        private void FeatureOnStateChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"FEATURE: {JsonSerializer.Serialize(sender)}");
            var feature = (IFeature) sender;
            var featureName = feature.GetName();
            if (_queueEnabled.Contains(featureName))
            {
                Console.WriteLine($"FEATURE UPDATED: {featureName}");
                _historyQueues[featureName].Enqueue(feature.GetState());
            }

            Console.WriteLine($"QUEUE LENGTH: {_historyQueues[featureName].Count}");
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
