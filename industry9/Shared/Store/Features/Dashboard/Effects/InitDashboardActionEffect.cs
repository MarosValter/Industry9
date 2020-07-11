using System;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.Dashboard.Actions;

namespace industry9.Shared.Store.Features.Dashboard.Effects
{
    public class InitDashboardActionEffect : Effect<InitDashboardAction>
    {
        private readonly IIndustry9Client _client;

        public InitDashboardActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(InitDashboardAction action, IDispatcher dispatcher)
        {
            if (string.IsNullOrEmpty(action.Id))
            {
                dispatcher.Dispatch(new UpsertDashboardResultAction(
                    new DashboardDetail(null, null, null, DateTimeOffset.Now,
                        Enumerable.Empty<ILabel>().ToList(), Enumerable.Empty<IWidgetId>().ToList())));
                return;
            }

            var result = await _client.GetDashboardAsync(action.Id);
            if (!result.HasErrors && result.Data != null)
            {
                var resultAction = new UpsertDashboardResultAction(result.Data.Dashboard);
                dispatcher.Dispatch(resultAction);
            }
            else
            {
                result.DispatchToast(dispatcher, null, "Unable to fetch Dashboard");
            }
        }
    }
}
