using System.Linq;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.DataSourceDefinition
{
    public class DataSourceDefinitionInputType : InputObjectType<DataSourceDefinitionDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DataSourceDefinitionDocument> descriptor)
        {
            descriptor.Name("DataSourceDefinitionInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.Id);
            descriptor.Field(d => d.Name).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.Type);
            descriptor.Field(d => d.Inputs).DefaultValue(Enumerable.Empty<string>().ToList());
        }
    }
}
