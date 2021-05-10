using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.GraphQL.UI.Scalars;

namespace industry9.GraphQL.UI.InputTypes
{
    public class DashboardWidgetInputType : InputObjectType<DashboardWidgetData>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DashboardWidgetData> descriptor)
        {
            descriptor.Name("DashboardWidgetInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.DashboardId).Type<NonNullType<IdType>>();
            descriptor.Field(d => d.WidgetId).Type<NonNullType<IdType>>();
            descriptor.Field(d => d.Size).Type<NonNullType<SizeType>>();
            descriptor.Field(d => d.Position).Type<NonNullType<PositionType>>();
        }
    }
}
