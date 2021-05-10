using System.Linq;
using HotChocolate.Types;
using industry9.Common.Enums;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.InputTypes
{
    public class DataSourceDefinitionInputType : InputObjectType<DataSourceDefinitionDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DataSourceDefinitionDocument> descriptor)
        {
            descriptor.Name("DataSourceDefinitionInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.Id).Type<IdType>();
            descriptor.Field(d => d.Name).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.Type).Type<NonNullType<EnumType<DataSourceType>>>();
            descriptor.Field(d => d.Inputs).DefaultValue(Enumerable.Empty<string>().ToList());
            descriptor.Field(d => d.Columns).DefaultValue(Enumerable.Empty<ExportedColumnData>().ToList());
        }
    }
}
