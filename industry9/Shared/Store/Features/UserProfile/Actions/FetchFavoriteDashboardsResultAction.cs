using System.Collections.Generic;

namespace industry9.Shared.Store.Features.UserProfile.Actions
{
    public class FetchFavoriteDashboardsResultAction
    {
        public IDashboardLite SelectedDashboard { get; }
        public IEnumerable<IDashboardLite> Dashboards { get; }

        public FetchFavoriteDashboardsResultAction(IDashboardLite selectedDashboard, IEnumerable<IDashboardLite> dashboards)
        {
            SelectedDashboard = selectedDashboard;
            Dashboards = dashboards;
        }
    }
}
