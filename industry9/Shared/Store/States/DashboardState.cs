using System.Collections.Generic;
using industry9.Shared.Dto.Dashboard;

namespace industry9.Shared.Store.States
{
    public class DashboardState
    {
        public IEnumerable<IDashboardLite> Dashboards { get; }
        public DashboardData EditedDashboard { get; }

        public DashboardState(IEnumerable<IDashboardLite> dashboards, DashboardData editedDashboard)
        {
            Dashboards = dashboards;
            EditedDashboard = editedDashboard;
        }
    }
}
