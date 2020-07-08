using System;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Services;
using industry9.GraphQL.UI.Base;

namespace industry9.GraphQL.UI.DataSourceDefinition
{
    public class DataSourceDefinitionType : BaseDocumentType<DataSourceDefinitionDocument>
    {
        protected override void Configure(IObjectTypeDescriptor<DataSourceDefinitionDocument> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name("DataSourceDefinition");
            descriptor.Field(d => d.Properties).Ignore().Resolver(ctx =>
            {
                var service = ctx.Service<IDataSourcePropertiesService>();
                var parent = ctx.Parent<DataSourceDefinitionDocument>();
                return Convert.ChangeType(parent.Properties, service.GetPropertiesType(parent.Type));
            });
        }
    }
}
