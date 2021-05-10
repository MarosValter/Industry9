using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Navigation;
using industry9.Client.Data.Store.Features.Dashboard.Reducers;
using industry9.Client.Data.Store.Features.Homepage.Actions;
using industry9.Client.Data.Store.Features.UserProfile.Actions;
using StrawberryShake; //using industry9.Shared.Store.Features.AppBar.Actions;

namespace industry9.Client.Data.Store.Features.Homepage.Effects
{
    public class SelectDashboardActionEffect : Effect<SelectDashboardAction>
    {
        private readonly Iindustry9Client _client;
        private readonly industry9NavigationManager _navigationManager;

        public SelectDashboardActionEffect(Iindustry9Client client, industry9NavigationManager navigationManager)
        {
            _client = client;
            _navigationManager = navigationManager;
        }

        protected override async Task HandleAsync(SelectDashboardAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetDashboard.ExecuteAsync(action.DashboardId);

            if (result.IsSuccessResult() && result.Data != null)
            {
                //dispatcher.Dispatch(new SetAppBarAction(result.Data.Dashboard.Name, null));
                dispatcher.Dispatch(new FetchDashboardResultAction(DashboardReducer.MapDashboard(result.Data.Dashboard)));
                _navigationManager.NavigateTo("/");
            }

            //TODO dispatch confirm/fail message action
        }
    }
}
