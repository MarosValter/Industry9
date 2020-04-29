using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Dashboard;
using MongoDB.Bson;

namespace industry9.GraphQL.UI.Dashboard
{
    [ExtendObjectType(Name = "Query")]
    public class DashboardQueries
    {
        public IEnumerable<DashboardDocument> GetDashboards([Service] IDashboardRepository dashboardRepository)
        {
            return dashboardRepository.GetAllDocuments();
        }

        public async Task<DashboardDocument> GetDashboard(ObjectId id, IResolverContext ctx, [Service] IDashboardRepository dashboardRepository)
        {
            var dashboard = await dashboardRepository.GetDocumentAsync(id);
            if (dashboard == null)
            {
                ctx.ReportError($"Dashboard with Id {id} not found.");
            }

            return dashboard;
        }
    }
}
