using System;
using Fluxor;

namespace industry9.Shared.Store.UserProfile
{
    public class UserProfileFeature : Feature<UserProfileState>
    {
        public override string GetName() => "UserProfile";

        protected override UserProfileState GetInitialState()
        {
            return new UserProfileState(false, Array.Empty<IDashboardLite>(), null);
        }
    }
}
