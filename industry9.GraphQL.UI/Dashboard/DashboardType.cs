using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Widget;
using industry9.GraphQL.UI.Base;
using industry9.GraphQL.UI.Widget;
using MongoDB.Bson;

namespace industry9.GraphQL.UI.Dashboard
{
    public class DashboardType : BaseDocumentType<DashboardDocument>
    {
        protected override void Configure(IObjectTypeDescriptor<DashboardDocument> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name("Dashboard");
            descriptor.Field(d => d.Widgets)
                .Type<ListType<WidgetType>>()
                .Resolver(async ctx =>
                {
                    var repository = ctx.Service<IWidgetRepository>();
                    var dataLoader =
                        ctx.BatchDataLoader<ObjectId, WidgetDocument>("WidgetsById", repository.GetDocuments);
                    return await dataLoader.LoadAsync(ctx.Parent<DashboardDocument>().WidgetIds, ctx.RequestAborted);
                });

            descriptor.Field(d => d.WidgetIds).Ignore();
        }
    }
}
