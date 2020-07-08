using System.Collections.ObjectModel;
using System.Linq;
using Fluxor;
using industry9.Shared.Store.UserProfile;

namespace industry9.Shared.Store.Dashboard
{
    public static class DashboardReducer
    {
        [ReducerMethod]
        public static DashboardDetailState ReduceToggleEditModeAction(DashboardDetailState state, ToggleEditModeAction action)
            => new DashboardDetailState(false, action.Enabled, state.SelectedDashboard);

        [ReducerMethod]
        public static DashboardDetailState ReduceSelectDashboardAction(DashboardDetailState state, SelectDashboardAction action)
            => new DashboardDetailState(true, false, null);

        [ReducerMethod]
        public static DashboardDetailState ReduceFetchDashboardResultAction(DashboardDetailState state, FetchDashboardResultAction action)
            => new DashboardDetailState(false, false, action.Dashboard);

        [ReducerMethod]
        public static DashboardDetailState ReduceAddLabelAction(DashboardDetailState state, AddLabelAction action)
            => new DashboardDetailState(state.IsLoading, state.EditMode,
                new DashboardDetail(state.SelectedDashboard.Id, state.SelectedDashboard.Name,
                    state.SelectedDashboard.AuthorId, state.SelectedDashboard.Created,
                    new ReadOnlyCollection<ILabel>(state.SelectedDashboard.Labels.Concat(new []{action.Label}).ToList()),
                    state.SelectedDashboard.Widgets));

        [ReducerMethod]
        public static DashboardDetailState ReduceRemoveLabelAction(DashboardDetailState detailState, RemoveLabelAction action)
            => new DashboardDetailState(detailState.IsLoading, detailState.EditMode,
                new DashboardDetail(detailState.SelectedDashboard.Id, detailState.SelectedDashboard.Name,
                    detailState.SelectedDashboard.AuthorId, detailState.SelectedDashboard.Created,
                    new ReadOnlyCollection<ILabel>(detailState.SelectedDashboard.Labels.Where(l => l.Name != action.LabelName).ToList()),
                    detailState.SelectedDashboard.Widgets));
    }
}
