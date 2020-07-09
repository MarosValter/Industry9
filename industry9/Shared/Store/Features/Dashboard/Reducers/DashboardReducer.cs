using Fluxor;
using industry9.Shared.Store.Features.Dashboard.Actions;
using industry9.Shared.Store.Features.UserProfile.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Dashboard.Reducers
{
    public static class DashboardReducer
    {
        [ReducerMethod]
        public static HomepageState ReduceToggleEditModeAction(HomepageState state, ToggleEditModeAction action)
            => new HomepageState(false, action.Enabled, state.Dashboard);

        [ReducerMethod]
        public static HomepageState ReduceSelectDashboardAction(HomepageState state, SelectDashboardAction action)
            => new HomepageState(true, false, null);

        [ReducerMethod]
        public static DashboardState ReduceFetchDashboardsResultAction(
            DashboardState state, FetchDashboardsResultAction action)
            => new DashboardState(action.Dashboards, state.EditedDashboard);

        [ReducerMethod]
        public static DashboardState ReduceUpsertDashboardsResultAction(
            DashboardState state, UpsertDashboardResultAction action)
            => new DashboardState(state.Dashboards, action.Dashboard);
    }
}
