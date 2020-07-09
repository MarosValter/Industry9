﻿using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Navigation;
using industry9.Shared.Store.Features.AppBar.Actions;
using industry9.Shared.Store.Features.Dashboard.Actions;
using industry9.Shared.Store.Features.UserProfile.Actions;

namespace industry9.Shared.Store.Features.Dashboard.Effects
{
    public class SelectDashboardActionEffect : Effect<SelectDashboardAction>
    {
        private readonly IIndustry9Client _client;
        private readonly industry9NavigationManager _navigationManager;

        public SelectDashboardActionEffect(IIndustry9Client client, industry9NavigationManager navigationManager)
        {
            _client = client;
            _navigationManager = navigationManager;
        }

        protected override async Task HandleAsync(SelectDashboardAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetDashboardAsync(action.Dashboard.Id);
            dispatcher.Dispatch(new SetAppBarAction(result.Data.Dashboard.Name, null));
            dispatcher.Dispatch(new FetchDashboardResultAction(result.Data.Dashboard));
        }
    }
}
