using System.Collections.Generic;

namespace industry9.Shared.Store.Features.UserProfile.Actions
{
    public class FetchFavoriteDashboardsResultAction
    {
        public string SelectedDashboardId { get; }
        public IEnumerable<IDashboardLite> Dashboards { get; }

        public FetchFavoriteDashboardsResultAction(string selectedDashboardId, IEnumerable<IDashboardLite> dashboards)
        {
            SelectedDashboardId = selectedDashboardId;
            Dashboards = dashboards;
        }
    }
}
