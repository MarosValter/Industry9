using System.Linq;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.Widget
{
    public class WidgetInputType : InputObjectType<WidgetDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<WidgetDocument> descriptor)
        {
            descriptor.Name("WidgetInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.Id);
            descriptor.Field(d => d.Name).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.Type);
            descriptor.Field(d => d.Labels).DefaultValue(Enumerable.Empty<LabelData>().ToList());
            descriptor.Field(d => d.ColumnMappings).DefaultValue(Enumerable.Empty<ColumnMappingData>().ToList());
        }
    }
}
