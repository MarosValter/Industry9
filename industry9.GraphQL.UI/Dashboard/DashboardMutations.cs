using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Dashboard;
using MongoDB.Bson;

namespace industry9.GraphQL.UI.Dashboard
{
    [ExtendObjectType(Name = "Mutation")]
    public class DashboardMutations
    {
        public async Task<DashboardDocument> CreateDashboard(DashboardDocument dashboard, [Service] IDashboardRepository dashboardRepository)
        {
            await dashboardRepository.CreateDocumentAsync(dashboard);
            return dashboard;
        }

        public async Task<bool> AddWidgetsToDashboard(ObjectId dashboardId, IReadOnlyCollection<ObjectId> widgetIds,
            [Service] IDashboardRepository dashboardRepository)
        {
            var result = await dashboardRepository.AddWidgetsToDashboard(dashboardId, widgetIds);
            return result.IsAcknowledged;
        }
    }
}
