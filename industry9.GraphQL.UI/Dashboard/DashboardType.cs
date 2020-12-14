using System.Linq;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Widget;
using industry9.GraphQL.UI.Base;

namespace industry9.GraphQL.UI.Dashboard
{
    public class DashboardType : BaseDocumentType<DashboardDocument>
    {
        protected override void Configure(IObjectTypeDescriptor<DashboardDocument> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name("Dashboard");
            descriptor.Field(d => d.Widgets)
                .Resolver(async ctx =>
                {
                    var dashboardWidgets = ctx.Parent<DashboardDocument>().Widgets;
                    var dashboardWidgetIds = dashboardWidgets.Select(x => x.WidgetId).Distinct().ToList();
                    var repository = ctx.Service<IWidgetRepository>();
                    var dataLoader =
                        ctx.BatchDataLoader<string, WidgetDocument>("WidgetsById", repository.GetDocuments);
                    var widgets = await dataLoader.LoadAsync(dashboardWidgetIds, ctx.RequestAborted);
                    foreach (var dashboardWidget in dashboardWidgets)
                    {
                        dashboardWidget.DashboardId = ctx.Parent<DashboardDocument>().Id;

                        var widget = widgets.FirstOrDefault(x => x.Id == dashboardWidget.WidgetId);
                        if (widget != null)
                        {
                            dashboardWidget.Widget = widget;
                        }
                    }

                    return dashboardWidgets;
                });
        }
    }
}
