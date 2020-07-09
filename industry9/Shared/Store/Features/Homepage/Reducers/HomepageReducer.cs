using Fluxor;
using industry9.Shared.Store.Features.Dashboard.Actions;
using industry9.Shared.Store.Features.Homepage.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Homepage.Reducers
{
    public class HomepageReducer
    {
        [ReducerMethod]
        public static HomepageState ReduceFetchDashboardResultAction(HomepageState state, FetchDashboardResultAction action)
            => new HomepageState(false, false, action.Dashboard);
    }
}
