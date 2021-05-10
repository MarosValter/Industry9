using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Store.Features.UserProfile.Actions;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.UserProfile.Effects
{
    public class FetchUserProfileActionEffect : Effect<FetchFavoriteDashboardsAction>
    {
        private readonly Iindustry9Client _client;

        public FetchUserProfileActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(FetchFavoriteDashboardsAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetDashboards.ExecuteAsync();
            if (result.IsSuccessResult() && result.Data != null)
            {
                // TODO fetch selected dashboard from user profile
                dispatcher.Dispatch(new FetchFavoriteDashboardsResultAction(result.Data.Dashboards?.FirstOrDefault()?.Id, result.Data.Dashboards));
            }
            
        }
    }
}
