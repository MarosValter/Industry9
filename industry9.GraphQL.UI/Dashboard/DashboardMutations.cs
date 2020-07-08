using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Dashboard;

namespace industry9.GraphQL.UI.Dashboard
{
    [ExtendObjectType(Name = "Mutation")]
    public class DashboardMutations
    {
        public async Task<DashboardDocument> CreateDashboard(DashboardDocument dashboard,
            [Service] IDashboardRepository dashboardRepository, IResolverContext ctx)
        {
            await dashboardRepository.CreateDocumentAsync(dashboard, ctx.RequestAborted);
            return dashboard;
        }

        public async Task<bool> AddWidgetsToDashboard(string dashboardId, IReadOnlyCollection<string> widgetIds,
            [Service] IDashboardRepository dashboardRepository, IResolverContext ctx)
        {
            var result = await dashboardRepository.AddWidgetsToDashboard(dashboardId, widgetIds, ctx.RequestAborted);
            return result.IsAcknowledged;
        }
    }
}
