using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Dashboard;

namespace industry9.GraphQL.UI.Mutations
{
    [ExtendObjectType("Mutation")]
    public class DashboardMutations
    {
        public async Task<string> UpsertDashboard(
            DashboardDocument dashboard,
            [Service] IDashboardRepository dashboardRepository,
            IResolverContext ctx)
        {
            await dashboardRepository.UpsertDocumentAsync(dashboard, ctx.RequestAborted);
            return dashboard.Id;
        }

        public async Task<bool> DeleteDashboard(
            [ID(nameof(DashboardDocument))] string id,
            [Service] IDashboardRepository dashboardRepository,
            IResolverContext ctx)
        {
            var result = await dashboardRepository.DeleteDocumentAsync(id, ctx.RequestAborted);
            return result.IsAcknowledged;
        }

        public async Task<bool> AddWidgetToDashboard(
            DashboardWidgetData widget,
            [Service] IDashboardRepository dashboardRepository,
            IResolverContext ctx)
        {
            var result = await dashboardRepository.AddWidgetToDashboard(widget, ctx.RequestAborted);
            return result.IsAcknowledged;
        }

        public async Task<bool> RemoveWidgetFromDashboard(
            [ID(nameof(DashboardDocument))] string dashboardId,
            [ID(nameof(WidgetDocument))] string widgetId,
            [Service] IDashboardRepository dashboardRepository,
            IResolverContext ctx)
        {
            var result = await dashboardRepository.RemoveWidgetFromDashboard(dashboardId, widgetId, ctx.RequestAborted);
            return result.IsAcknowledged;
        }
    }
}
