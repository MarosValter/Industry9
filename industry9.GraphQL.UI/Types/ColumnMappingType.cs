using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.Types
{
    public class ColumnMappingType : ObjectType<ColumnMappingData>
    {
        protected override void Configure(IObjectTypeDescriptor<ColumnMappingData> descriptor)
        {
            descriptor.Name("ColumnMapping");
            descriptor.Field(d => d.DataSourceId).Type<NonNullType<IdType>>();
        }
    }
}
