using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Dashboard;

namespace industry9.GraphQL.UI.Dashboard
{
    [ExtendObjectType(Name = "Query")]
    public class DashboardQueries
    {
        public IEnumerable<DashboardDocument> GetDashboards([Service] IDashboardRepository dashboardRepository)
        {
            return dashboardRepository.GetAllDocuments();
        }

        public async Task<DashboardDocument> GetDashboard(string id,
            [Service] IDashboardRepository dashboardRepository, IResolverContext ctx)
        {
            var dashboard = await dashboardRepository.GetDocumentAsync(id, ctx.RequestAborted);
            if (dashboard == null)
            {
                ctx.ReportError($"Dashboard with Id {id} not found.");
            }

            return dashboard;
        }
    }
}
