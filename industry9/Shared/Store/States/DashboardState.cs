using System.Collections.Generic;
using System.Linq;
using industry9.Shared.Dto.Dashboard;

namespace industry9.Shared.Store.States
{
    public class DashboardState
    {
        public IEnumerable<IDashboardLite> Dashboards { get; }
        public DashboardData EditedDashboard { get; }

        public DashboardState(IEnumerable<IDashboardLite> dashboards, DashboardData editedDashboard)
        {
            Dashboards = dashboards ?? Enumerable.Empty<IDashboardLite>();
            EditedDashboard = editedDashboard ?? new DashboardData();
        }
    }
}
