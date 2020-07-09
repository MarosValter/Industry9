using System.Collections.Generic;

namespace industry9.Shared.Store.States
{
    public class DashboardListingState
    {
        public IEnumerable<IDashboardLite> Dashboards { get; }

        public DashboardListingState(IEnumerable<IDashboardLite> dashboards)
        {
            Dashboards = dashboards;
        }
    }
}
