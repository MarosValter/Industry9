using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.Dashboard.Actions;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.Dashboard.Effects
{
    public class FetchDashboardsActionEffect : Effect<FetchDashboardsAction>
    {
        private readonly Iindustry9Client _client;

        public FetchDashboardsActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(FetchDashboardsAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetDashboards.ExecuteAsync();
            if (result.IsSuccessResult() && result.Data != null)
            {
                dispatcher.Dispatch(new FetchDashboardsResultAction(result.Data.Dashboards));
            }
            else
            {
                result.DispatchToast(dispatcher, null, "Unable to fetch Dashboards");
            }
        }
    }
}
