using System.Collections.Generic;

namespace industry9.Shared.Store.Features.Dashboard.Actions
{
    public class FetchDashboardsResultAction
    {
        public IEnumerable<IDashboardLite> Dashboards { get; }

        public FetchDashboardsResultAction(IEnumerable<IDashboardLite> dashboards)
        {
            Dashboards = dashboards;
        }
    }
}
