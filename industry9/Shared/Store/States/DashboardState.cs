using System.Collections.Generic;

namespace industry9.Shared.Store.States
{
    public class DashboardState
    {
        public IEnumerable<IDashboardLite> Dashboards { get; }
        public IDashboardDetail EditedDashboard { get; }

        public DashboardState(IEnumerable<IDashboardLite> dashboards, IDashboardDetail editedDashboard)
        {
            Dashboards = dashboards;
            EditedDashboard = editedDashboard;
        }
    }
}
