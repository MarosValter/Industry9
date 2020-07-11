using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Store.Base;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.Dashboard.Actions;

namespace industry9.Shared.Store.Features.Dashboard.Effects
{
    public class UpsertDashboardActionEffect : Effect<UpsertDashboardResultAction>
    {
        private readonly IIndustry9Client _client;

        public UpsertDashboardActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(UpsertDashboardResultAction action, IDispatcher dispatcher)
        {
            if (!action.SaveChanges)
            {
                return;
            }

            var input = CreateInput(action.Dashboard);
            var result = await _client.UpsertDashboardAsync(input);

            if (!result.HasErrors)
            {
                dispatcher.Dispatch(new FetchDashboardsAction());
            }

            result.DispatchToast(dispatcher, "Dashboard", string.IsNullOrEmpty(action.Dashboard.Id) ? CRUDOperation.Create : CRUDOperation.Update);
        }

        private DashboardInput CreateInput(IDashboardDetail dashboard)
        {
            var input = new DashboardInput
            {
                Id = dashboard.Id,
                Name = dashboard.Name,
                Labels = dashboard.Labels.Select(x => new LabelDataInput { Name = x.Name }).ToList(),
                WidgetIds = dashboard.Widgets.Select(x => x.Id).ToList()
            };

            return input;
        }
    }
}
