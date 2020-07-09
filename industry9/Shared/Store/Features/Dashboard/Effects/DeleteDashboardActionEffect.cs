using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Store.Base;
using industry9.Shared.Store.Features.Dashboard.Actions;

namespace industry9.Shared.Store.Features.Dashboard.Effects
{
    public class DeleteDashboardActionEffect : Effect<DeleteDashboardAction>
    {
        private readonly IIndustry9Client _client;

        public DeleteDashboardActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(DeleteDashboardAction action, IDispatcher dispatcher)
        {
            var result = await _client.DeleteDashboardAsync(action.Id);
            if (!result.HasErrors && result.Data?.DeleteDashboard == true)
            {
                dispatcher.Dispatch(new FetchDashboardsAction());
            }

            result.DispatchToast(dispatcher, "Dashboard", CRUDOperation.Delete);
        }
    }
}
