using Fluxor;

namespace industry9.Shared.Store.UserProfile
{
    public static class UserProfileReducer
    {
        [ReducerMethod]
        public static UserProfileState ReduceSelectDashboardAction(UserProfileState state, SelectDashboardAction action)
            => new UserProfileState(false, state.Dashboards, action.Dashboard);

        [ReducerMethod]
        public static UserProfileState ReduceFetchUserProfileResultAction(UserProfileState state, FetchUserProfileResultAction action)
            => new UserProfileState(false, action.Dashboards, action.SelectedDashboard);
    }
}
