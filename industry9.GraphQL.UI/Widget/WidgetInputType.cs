using System.Linq;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.Widget
{
    public class WidgetInputType : InputObjectType<WidgetInputDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<WidgetInputDocument> descriptor)
        {
            descriptor.Name("WidgetInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.Name).Type<NonNullType<StringType>>();
            //descriptor.Field(d => d.Position);
            //descriptor.Field(d => d.Size);
            descriptor.Field(d => d.Labels).DefaultValue(Enumerable.Empty<LabelData>().ToList());
            descriptor.Field(d => d.ColumnMappings).DefaultValue(Enumerable.Empty<ColumnMappingData>().ToList());
            descriptor.Field(d => d.DataSourceIds).DefaultValue(Enumerable.Empty<string>().ToList());
            descriptor.Field(d => d.DashboardId);
        }
    }
}
