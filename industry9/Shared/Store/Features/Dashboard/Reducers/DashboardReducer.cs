using System.Collections.ObjectModel;
using System.Linq;
using Fluxor;
using industry9.Shared.Store.Features.Dashboard.Actions;
using industry9.Shared.Store.Features.UserProfile.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Dashboard.Reducers
{
    public static class DashboardReducer
    {
        [ReducerMethod]
        public static DashboardDetailState ReduceToggleEditModeAction(DashboardDetailState state, ToggleEditModeAction action)
            => new DashboardDetailState(false, action.Enabled, state.Dashboard);

        [ReducerMethod]
        public static DashboardDetailState ReduceSelectDashboardAction(DashboardDetailState state, SelectDashboardAction action)
            => new DashboardDetailState(true, false, null);

        [ReducerMethod]
        public static DashboardDetailState ReduceFetchDashboardResultAction(DashboardDetailState state, FetchDashboardResultAction action)
            => new DashboardDetailState(false, false, action.Dashboard);

        [ReducerMethod]
        public static DashboardDetailState ReduceAddLabelAction(DashboardDetailState state, AddLabelAction action)
            => new DashboardDetailState(state.IsLoading, state.EditMode,
                new DashboardDetail(state.Dashboard.Id, state.Dashboard.Name,
                    state.Dashboard.AuthorId, state.Dashboard.Created,
                    new ReadOnlyCollection<ILabel>(state.Dashboard.Labels.Concat(new []{action.Label}).ToList()),
                    state.Dashboard.Widgets));

        [ReducerMethod]
        public static DashboardDetailState ReduceRemoveLabelAction(DashboardDetailState detailState, RemoveLabelAction action)
            => new DashboardDetailState(detailState.IsLoading, detailState.EditMode,
                new DashboardDetail(detailState.Dashboard.Id, detailState.Dashboard.Name,
                    detailState.Dashboard.AuthorId, detailState.Dashboard.Created,
                    new ReadOnlyCollection<ILabel>(detailState.Dashboard.Labels.Where(l => l.Name != action.LabelName).ToList()),
                    detailState.Dashboard.Widgets));
    }
}
