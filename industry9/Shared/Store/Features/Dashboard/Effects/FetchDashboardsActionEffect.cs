using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Base;
using industry9.Shared.Store.Features.Dashboard.Actions;

namespace industry9.Shared.Store.Features.Dashboard.Effects
{
    public class FetchDashboardsActionEffect : Effect<FetchDashboardsAction>
    {
        private readonly IIndustry9Client _client;

        public FetchDashboardsActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(FetchDashboardsAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetDashboardsAsync();
            if (!result.HasErrors && result.Data != null)
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
