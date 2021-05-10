using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Dto.Dashboard;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.Dashboard.Actions;
using industry9.Client.Data.Store.Features.UserProfile.Actions;
using industry9.Common.Enums;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.Dashboard.Effects
{
    public class UpsertDashboardActionEffect : Effect<UpsertDashboardResultAction>
    {
        private readonly Iindustry9Client _client;

        public UpsertDashboardActionEffect(Iindustry9Client client)
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
            var result = await _client.UpsertDashboard.ExecuteAsync(input);

            if (result.IsSuccessResult())
            {
                dispatcher.Dispatch(new FetchDashboardsAction());
                dispatcher.Dispatch(new FetchFavoriteDashboardsAction());
                
                if (operation == CRUDOperation.Create)
                {
                    dispatcher.Dispatch(new InitDashboardAction(action.Dashboard.Id));
                    dispatcher.Dispatch(new ToggleEditModeAction(true));
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
                Widgets = dashboard.Widgets.Select(x => UpsertDashboardWidgetActionEffect.MapDashboardWidgetInput(dashboard.Id, x)).ToList()
            };

            return input;
        }
    }
}
