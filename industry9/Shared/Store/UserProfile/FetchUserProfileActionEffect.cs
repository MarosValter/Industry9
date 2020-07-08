using System.Threading.Tasks;
using Fluxor;

namespace industry9.Shared.Store.UserProfile
{
    public class FetchUserProfileActionEffect : Effect<FetchUserProfileAction>
    {
        private readonly IIndustry9Client _client;

        public FetchUserProfileActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(FetchUserProfileAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetDashboardsAsync();
            // TODO fetch selected dashboard from user profile
            dispatcher.Dispatch(new FetchUserProfileResultAction(null, result.Data.Dashboards));
        }
    }
}
