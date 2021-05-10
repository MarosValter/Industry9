using System.Linq;
using Fluxor;
using industry9.Client.Data.Store.Features.UserProfile.Actions;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.UserProfile.Reducers
{
    public static class UserProfileReducer
    {
        [ReducerMethod]
        public static UserProfileState ReduceSelectDashboardAction(UserProfileState state, SelectDashboardAction action)
            => new UserProfileState(false, state.Dashboards, state.Dashboards.FirstOrDefault(x => x.Id == action.DashboardId));

        [ReducerMethod]
        public static UserProfileState ReduceFetchUserProfileResultAction(UserProfileState state, FetchFavoriteDashboardsResultAction action)
            => new UserProfileState(false, action.Dashboards, action.Dashboards.FirstOrDefault(x => x.Id == action.SelectedDashboardId));
    }
}
