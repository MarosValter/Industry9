using System.Linq;
using Fluxor;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.UserProfile
{
    public class UserProfileFeature : Feature<UserProfileState>
    {
        public override string GetName() => "UserProfile";

        protected override UserProfileState GetInitialState()
        {
            return new UserProfileState(false, Enumerable.Empty<IDashboardLite>(), null);
        }
    }
}
