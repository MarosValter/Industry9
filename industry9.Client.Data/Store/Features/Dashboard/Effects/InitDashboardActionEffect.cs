using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Dto.Dashboard;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.Dashboard.Actions;
using industry9.Client.Data.Store.Features.Dashboard.Reducers;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.Dashboard.Effects
{
    public class InitDashboardActionEffect : Effect<InitDashboardAction>
    {
        private readonly Iindustry9Client _client;

        public InitDashboardActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(InitDashboardAction action, IDispatcher dispatcher)
        {
            if (string.IsNullOrEmpty(action.Id))
            {
                dispatcher.Dispatch(new UpsertDashboardResultAction(new DashboardData()));
                return;
            }

            var result = await _client.GetDashboard.ExecuteAsync(action.Id);
            if (result.IsSuccessResult() && result.Data != null)
            {
                var resultAction = new UpsertDashboardResultAction(DashboardReducer.MapDashboard(result.Data.Dashboard));
                dispatcher.Dispatch(resultAction);
            }
            else
            {
                result.DispatchToast(dispatcher, null, "Unable to fetch Dashboard");
            }
        }
    }
}
