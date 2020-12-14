using System.Linq;
using Fluxor;
using industry9.Shared.Store.Features.WidgetSource.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.WidgetSource.Reducers
{
    public static class WidgetSourceReducer
    {
        [ReducerMethod]
        public static WidgetSourceState ReduceDataReceivedResultAction(
            WidgetSourceState state, DataReceivedResultAction action)
        {
            var widgetData = action.Data;
            if (state.WidgetData.Contains(action.WidgetId))
            {
                widgetData = state.WidgetData[action.WidgetId].Concat(widgetData).OrderBy(x => x.Timestamp).ToList();
            }

            var data = state.WidgetData.Where(x => x.Key != action.WidgetId);

            return new WidgetSourceState(
                data.Concat(
                    widgetData.GroupBy(x => action.WidgetId))
                    .SelectMany(x => 
                        x.Select(y => 
                            new { widgetId = x.Key, data = y }))
                    .ToLookup(
                        k => k.widgetId, 
                        v => v.data));
        }
    }
}
