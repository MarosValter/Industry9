using System.Collections.Generic;
using industry9.Client.Data.GraphQL.Generated;

namespace industry9.Client.Data.Store.Features.Dashboard.Actions
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
