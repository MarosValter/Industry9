using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.DataSourceDefinition
{
    public class DataSourceDefinitionInputType : InputObjectType<DataSourceDefinitionDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DataSourceDefinitionDocument> descriptor)
        {
            descriptor.Name("DataSourceDefinitionInput");
            descriptor.Field(d => d.Properties).Ignore();
        }
    }
}
