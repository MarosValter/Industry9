using Fluxor;
using industry9.Shared.Store.Features.Homepage.Actions;
using industry9.Shared.Store.Features.UserProfile.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Homepage.Reducers
{
    public class HomepageReducer
    {
        [ReducerMethod]
        public static HomepageState ReduceSelectDashboardAction(HomepageState state, SelectDashboardAction action)
            => new HomepageState(true, state.Dashboard);

        [ReducerMethod]
        public static HomepageState ReduceFetchDashboardResultAction(HomepageState state, FetchDashboardResultAction action)
            => new HomepageState(false, action.Dashboard);
    }
}
