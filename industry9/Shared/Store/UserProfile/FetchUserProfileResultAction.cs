using System.Collections.Generic;

namespace industry9.Shared.Store.UserProfile
{
    public class FetchUserProfileResultAction
    {
        public IDashboardLite SelectedDashboard { get; }
        public IEnumerable<IDashboardLite> Dashboards { get; }

        public FetchUserProfileResultAction(IDashboardLite selectedDashboard, IEnumerable<IDashboardLite> dashboards)
        {
            SelectedDashboard = selectedDashboard;
            Dashboards = dashboards;
        }
    }
}
