using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.GraphQL.UI.Base;

namespace industry9.GraphQL.UI.DataSourceDefinition
{
    public class DataSourceDefinitionType : BaseDocumentType<DataSourceDefinitionDocument>
    {
        protected override void Configure(IObjectTypeDescriptor<DataSourceDefinitionDocument> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name("DataSourceDefinition");
            descriptor.Field(d => d.Properties).Ignore();
        }
    }
}
