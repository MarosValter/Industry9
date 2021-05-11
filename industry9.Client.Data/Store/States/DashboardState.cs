using System.Collections.Generic;
using System.Linq;
using industry9.Client.Data.Dto.Dashboard;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Base;

namespace industry9.Client.Data.Store.States
{
    public class DashboardState : IHistoryState
    {
        public IEnumerable<IDashboardLite> Dashboards { get; }
        public DashboardData EditedDashboard { get; }

        public bool CanUndo { get; }

        public DashboardState(IEnumerable<IDashboardLite> dashboards, DashboardData editedDashboard, bool canUndo = false)
        {
            Dashboards = dashboards ?? Enumerable.Empty<IDashboardLite>();
            EditedDashboard = editedDashboard ?? new DashboardData();
            CanUndo = canUndo;
        }
    }
}
