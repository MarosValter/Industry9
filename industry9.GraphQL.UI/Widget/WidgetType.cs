using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.DataSourceDefinition;
using industry9.GraphQL.UI.Base;
using MongoDB.Bson;

namespace industry9.GraphQL.UI.Widget
{
    public class WidgetType : BaseDocumentType<WidgetDocument>
    {
        protected override void Configure(IObjectTypeDescriptor<WidgetDocument> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name("Widget");
            descriptor.Field(d => d.DataSources)
                .Type<ListType<WidgetType>>()
                .Resolver(async ctx =>
                {
                    var repository = ctx.Service<IDataSourceDefinitionRepository>();
                    var dataLoader =
                        ctx.BatchDataLoader<ObjectId, DataSourceDefinitionDocument>("DataSourcesById", repository.GetDocuments);
                    return await dataLoader.LoadAsync(ctx.Parent<WidgetDocument>().DataSourceIds, ctx.RequestAborted);
                });

            descriptor.Field(d => d.DataSourceIds).Ignore();
        }
    }
}
