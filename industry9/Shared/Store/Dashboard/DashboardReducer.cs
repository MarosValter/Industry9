using System.Collections.ObjectModel;
using System.Linq;
using Fluxor;
using industry9.Shared.Store.UserProfile;

namespace industry9.Shared.Store.Dashboard
{
    public static class DashboardReducer
    {
        [ReducerMethod]
        public static DashboardState ReduceToggleEditModeAction(DashboardState state, ToggleEditModeAction action)
            => new DashboardState(false, action.Enabled, state.SelectedDashboard);

        [ReducerMethod]
        public static DashboardState ReduceSelectDashboardAction(DashboardState state, SelectDashboardAction action)
            => new DashboardState(true, false, null);

        [ReducerMethod]
        public static DashboardState ReduceFetchDashboardResultAction(DashboardState state, FetchDashboardResultAction action)
            => new DashboardState(false, false, action.Dashboard);

        [ReducerMethod]
        public static DashboardState ReduceAddLabelAction(DashboardState state, AddLabelAction action)
            => new DashboardState(state.IsLoading, state.EditMode,
                new Shared.Dashboard(state.SelectedDashboard.Id, state.SelectedDashboard.Name,
                    new ReadOnlyCollection<ILabelData>(state.SelectedDashboard.Labels.Concat(new []{action.Label}).ToList()),
                    state.SelectedDashboard.Widgets));

        [ReducerMethod]
        public static DashboardState ReduceRemoveLabelAction(DashboardState state, RemoveLabelAction action)
            => new DashboardState(state.IsLoading, state.EditMode,
                new Shared.Dashboard(state.SelectedDashboard.Id, state.SelectedDashboard.Name,
                    new ReadOnlyCollection<ILabelData>(state.SelectedDashboard.Labels.Where(l => l.Name != action.LabelName).ToList()),
                    state.SelectedDashboard.Widgets));
    }
}
