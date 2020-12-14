using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Dto.DashboardWidget;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.Dashboard.Actions;

namespace industry9.Shared.Store.Features.Dashboard.Effects
{
    public class UpsertDashboardWidgetActionEffect : Effect<UpsertDashboardWidgetResultAction>
    {
        private readonly IIndustry9Client _client;

        public UpsertDashboardWidgetActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(UpsertDashboardWidgetResultAction action, IDispatcher dispatcher)
        {
            if (!action.SaveChanges)
            {
                return;
            }

            var input = MapDashboardWidgetInput(action.DashboardWidget.DashboardId, action.DashboardWidget);
            var result = await _client.AddWidgetToDashboardAsync(input);

            if (!result.HasErrors)
            {
                dispatcher.Dispatch(new InitDashboardAction(action.DashboardWidget.DashboardId));
            }

            result.DispatchToast(dispatcher, "Dashboard Widget", action.New ? CRUDOperation.Create : CRUDOperation.Update);
        }

        //TODO automapper
        public static DashboardWidgetInput MapDashboardWidgetInput(string dashboardId, DashboardWidgetData dashboardWidget)
        {
            return new DashboardWidgetInput
            {
                DashboardId = dashboardId,
                WidgetId = dashboardWidget.WidgetId,
                Position = new PositionInput { X = dashboardWidget.Position.X, Y = dashboardWidget.Position.Y },
                Size = new SizeInput { Width = dashboardWidget.Size.Width, Height = dashboardWidget.Size.Height }
            };
        }
    }
}
