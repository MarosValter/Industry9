using System.Linq;
using Fluxor;
using industry9.Shared.Store.Features.WidgetSource.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.WidgetSource.Reducers
{
    public static class WidgetSourceReducer
    {
        [ReducerMethod]
        public static WidgetSourceState ReduceWidgetSourceResultAction(
            WidgetSourceState state, WidgetSourceResultAction action)
            => new WidgetSourceState(action.Widget ?? state.Widget, action.Data ?? state.Data);

        [ReducerMethod]
        public static WidgetSourceState ReduceDataReceivedResultAction(
            WidgetSourceState state, DataReceivedResultAction action)
            => new WidgetSourceState(state.Widget, state.Data.Concat(new[] {action.NewData}).ToList());
    }
}
