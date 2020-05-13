using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Dashboard;
using industry9.DataModel.UI.Repositories.Widget;

namespace industry9.GraphQL.UI.Widget
{
    [ExtendObjectType(Name = "Mutation")]
    public class WidgetMutations
    {
        public async Task<WidgetDocument> CreateWidget(WidgetInputDocument widget, IResolverContext context,
            [Service] IWidgetRepository widgetRepository, [Service] IDashboardRepository dashboardRepository)
        {
            await widgetRepository.CreateDocumentAsync(widget);

            //var args = context.Argument<IDictionary<string, object>>("widget");
            //if (args.TryGetValue("dashboardId", out var id) && id is string dashboardId)
            if (!string.IsNullOrEmpty(widget.DashboardId))
            {
                var addResult = await dashboardRepository.AddWidgetsToDashboard(widget.DashboardId, new []{ widget.Id });
                if (!addResult.IsAcknowledged)
                {
                    // TODO
                }
            }

            return widget;
        }
    }
}
