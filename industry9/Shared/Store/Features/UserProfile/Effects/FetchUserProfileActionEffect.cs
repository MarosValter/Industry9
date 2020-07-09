using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Features.UserProfile.Actions;

namespace industry9.Shared.Store.Features.UserProfile.Effects
{
    public class FetchUserProfileActionEffect : Effect<FetchFavoriteDashboardsAction>
    {
        private readonly IIndustry9Client _client;

        public FetchUserProfileActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(FetchFavoriteDashboardsAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetDashboardsAsync();
            // TODO fetch selected dashboard from user profile
            dispatcher.Dispatch(new FetchFavoriteDashboardsResultAction(null, result.Data.Dashboards));
        }
    }
}
