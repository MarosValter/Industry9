using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.Dashboard.Actions;

namespace industry9.Shared.Store.Features.Dashboard.Effects
{
    public class DeleteDashboardWidgetActionEffect : Effect<DeleteDashboardWidgetAction>
    {
        private readonly IIndustry9Client _client;

        public DeleteDashboardWidgetActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(DeleteDashboardWidgetAction action, IDispatcher dispatcher)
        {
            var result = await _client.RemoveWidgetFromDashboardAsync(action.DashboardId, action.WidgetId);
            if (!result.HasErrors && result.Data != null)
            {
                dispatcher.Dispatch(new InitDashboardAction(action.DashboardId));
            }

            result.DispatchToast(dispatcher, "Dashboard Widget", CRUDOperation.Delete);
        }
    }
}
