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
        public async Task<string> UpsertDashboard(DashboardDocument dashboard,
            [Service] IDashboardRepository dashboardRepository, IResolverContext ctx)
        {
            await dashboardRepository.UpsertDocumentAsync(dashboard, ctx.RequestAborted);
            return dashboard.Id;
        }

        public async Task<bool> DeleteDashboard(string id, [Service] IDashboardRepository dashboardRepository,
            IResolverContext ctx)
        {
            var result = await dashboardRepository.DeleteDocumentAsync(id, ctx.RequestAborted);
            return result.IsAcknowledged;
        }

        public async Task<bool> AddWidgetsToDashboard(string dashboardId, IReadOnlyCollection<string> widgetIds,
            [Service] IDashboardRepository dashboardRepository, IResolverContext ctx)
        {
            var result = await dashboardRepository.AddWidgetsToDashboard(dashboardId, widgetIds, ctx.RequestAborted);
            return result.IsAcknowledged;
        }
    }
}
