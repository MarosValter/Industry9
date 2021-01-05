using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Dto.Dashboard;
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

            var operation = string.IsNullOrEmpty(action.Dashboard.Id) ? CRUDOperation.Create : CRUDOperation.Update;
            var input = CreateInput(action.Dashboard);
            var result = await _client.UpsertDashboardAsync(input);

            if (!result.HasErrors)
            {
                dispatcher.Dispatch(new FetchDashboardsAction());
                if (operation == CRUDOperation.Create)
                {
                    dispatcher.Dispatch(new InitDashboardAction(action.Dashboard.Id));
                    dispatcher.Dispatch(new ToggleEditModeAction(true, false));
                }
            }

            result.DispatchToast(dispatcher, "Dashboard", operation);
        }

        //TODO automapper
        private DashboardInput CreateInput(DashboardData dashboard)
        {
            var input = new DashboardInput
            {
                Id = dashboard.Id,
                Name = dashboard.Name,
                ColumnCount = dashboard.ColumnCount,
                Private = dashboard.Private,
                Labels = dashboard.Labels.Select(x => new LabelDataInput { Name = x.Name }).ToList(),
            };

            return input;
        }
    }
}
