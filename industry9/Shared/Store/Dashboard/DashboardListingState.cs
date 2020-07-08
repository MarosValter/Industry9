using System;
using System.Collections.Generic;
using System.Text;

namespace industry9.Shared.Store.Dashboard
{
    public class DashboardListingState
    {
        public IEnumerable<IDashboardLite> Dashboards { get; set; }

        public DashboardListingState(IEnumerable<IDashboardLite> dashboards)
        {
            Dashboards = dashboards;
        }
    }
}
