using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.InputTypes
{
    public class ColumnMappingInputType : InputObjectType<ColumnMappingData>
    {
        protected override void Configure(IInputObjectTypeDescriptor<ColumnMappingData> descriptor)
        {
            descriptor.Name("ColumnMappingInput");
            descriptor.Field(d => d.DataSourceId).Type<NonNullType<IdType>>();
        }
    }
}
