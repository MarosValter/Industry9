using System.Linq;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.DataSourceDefinition;
using industry9.GraphQL.UI.Base;
using industry9.GraphQL.UI.DataSourceDefinition;

namespace industry9.GraphQL.UI.Widget
{
    public class WidgetType : BaseDocumentType<WidgetDocument>
    {
        protected override void Configure(IObjectTypeDescriptor<WidgetDocument> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name("Widget");
            descriptor.Field(d => d.DataSources)
                .Type<ListType<DataSourceDefinitionType>>()
                .Resolver(async ctx =>
                {
                    var repository = ctx.Service<IDataSourceDefinitionRepository>();
                    var dataLoader =
                        ctx.BatchDataLoader<string, DataSourceDefinitionDocument>("DataSourcesById", repository.GetDocuments);
                    return await dataLoader.LoadAsync(ctx.Parent<WidgetDocument>().ColumnMappings.Select(x => x.DataSourceId).ToList(), ctx.RequestAborted);
                });
        }
    }
}
