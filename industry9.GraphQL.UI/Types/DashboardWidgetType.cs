using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.GraphQL.UI.DataLoaders;
using industry9.GraphQL.UI.Scalars;

namespace industry9.GraphQL.UI.Types
{
    public class DashboardWidgetType : ObjectType<DashboardWidgetData>
    {
        protected override void Configure(IObjectTypeDescriptor<DashboardWidgetData> descriptor)
        {
            descriptor.Name("DashboardWidget");
            descriptor.Field(d => d.DashboardId).Ignore();
            descriptor.Field(d => d.WidgetId).Ignore();
            descriptor.Field(d => d.Size).Type<NonNullType<SizeType>>();
            descriptor.Field(d => d.Position).Type<NonNullType<PositionType>>();
            descriptor.Field(d => d.Widget).ResolveWith<WidgetLoader>(l => l.GetWidgetAsync(default!, default!, default));
        }

        private class WidgetLoader
        {
            public Task<WidgetDocument> GetWidgetAsync(
                DashboardWidgetData dashboardWidget,
                WidgetDataLoader loader,
                CancellationToken token)
            {
                return loader.LoadAsync(dashboardWidget.WidgetId, token);
            }
        }
    }
}
