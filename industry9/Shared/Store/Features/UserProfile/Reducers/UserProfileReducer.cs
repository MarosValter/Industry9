using Fluxor;
using industry9.Shared.Store.Features.UserProfile.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.UserProfile.Reducers
{
    public static class UserProfileReducer
    {
        [ReducerMethod]
        public static UserProfileState ReduceSelectDashboardAction(UserProfileState state, SelectDashboardAction action)
            => new UserProfileState(false, state.Dashboards, action.Dashboard);

        [ReducerMethod]
        public static UserProfileState ReduceFetchUserProfileResultAction(UserProfileState state, FetchFavoriteDashboardsResultAction action)
            => new UserProfileState(false, action.Dashboards, action.SelectedDashboard);
    }
}
