using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.Dashboard.Actions;
using industry9.Common.Enums;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.Dashboard.Effects
{
    public class DeleteDashboardWidgetActionEffect : Effect<DeleteDashboardWidgetAction>
    {
        private readonly Iindustry9Client _client;

        public DeleteDashboardWidgetActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(DeleteDashboardWidgetAction action, IDispatcher dispatcher)
        {
            var result = await _client.RemoveWidgetFromDashboard.ExecuteAsync(action.DashboardId, action.WidgetId);
            if (result.IsSuccessResult() && result.Data != null)
            {
                dispatcher.Dispatch(new InitDashboardAction(action.DashboardId));
            }

            result.DispatchToast(dispatcher, "Dashboard Widget", CRUDOperation.Delete);
        }
    }
}
