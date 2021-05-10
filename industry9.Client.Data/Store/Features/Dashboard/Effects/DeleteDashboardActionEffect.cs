using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.Dashboard.Actions;
using industry9.Common.Enums;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.Dashboard.Effects
{
    public class DeleteDashboardActionEffect : Effect<DeleteDashboardAction>
    {
        private readonly Iindustry9Client _client;

        public DeleteDashboardActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(DeleteDashboardAction action, IDispatcher dispatcher)
        {
            var result = await _client.DeleteDashboard.ExecuteAsync(action.Id);
            if (result.IsSuccessResult() && result.Data?.DeleteDashboard == true)
            {
                dispatcher.Dispatch(new FetchDashboardsAction());
            }

            result.DispatchToast(dispatcher, "Dashboard", CRUDOperation.Delete);
        }
    }
}
