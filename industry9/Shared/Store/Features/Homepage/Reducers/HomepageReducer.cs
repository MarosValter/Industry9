using Fluxor;
using industry9.Shared.Store.Features.Dashboard.Actions;
using industry9.Shared.Store.Features.Homepage.Actions;
using industry9.Shared.Store.Features.UserProfile.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Homepage.Reducers
{
    public class HomepageReducer
    {
        [ReducerMethod]
        public static HomepageState ReduceSelectDashboardAction(HomepageState state, SelectDashboardAction action)
            => new HomepageState(true, false, state.Dashboard);

        [ReducerMethod]
        public static HomepageState ReduceToggleEditModeAction(HomepageState state, ToggleEditModeAction action)
            => new HomepageState(false, action.Enabled, state.Dashboard);

        [ReducerMethod]
        public static HomepageState ReduceFetchDashboardResultAction(HomepageState state, FetchDashboardResultAction action)
            => new HomepageState(false, state.EditMode, action.Dashboard);

        [ReducerMethod]
        public static HomepageState ReduceUpsertDashboardWidgetResultAction(HomepageState state, UpsertDashboardResultAction action)
            => new HomepageState(false, state.EditMode, action.Dashboard);
    }
}
