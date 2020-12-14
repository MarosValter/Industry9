using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.GraphQL.UI.Position;
using industry9.GraphQL.UI.Size;

namespace industry9.GraphQL.UI.Dashboard
{
    public class DashboardWidgetInputType : InputObjectType<DashboardWidgetData>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DashboardWidgetData> descriptor)
        {
            descriptor.Name("DashboardWidgetInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.DashboardId).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.WidgetId).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.Size).Type<NonNullType<SizeInputType>>();
            descriptor.Field(d => d.Position).Type<NonNullType<PositionInputType>>();
        }
    }
}
