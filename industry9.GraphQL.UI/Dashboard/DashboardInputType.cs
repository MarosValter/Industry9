using System.Linq;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.Dashboard
{
    public class DashboardInputType : InputObjectType<DashboardDocument>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DashboardDocument> descriptor)
        {
            descriptor.Name("DashboardInput");
            descriptor.BindFieldsExplicitly();
            descriptor.Field(d => d.Id);
            descriptor.Field(d => d.Name).Type<NonNullType<StringType>>();
            descriptor.Field(d => d.Labels).DefaultValue(Enumerable.Empty<LabelData>().ToList());
            descriptor.Field(d => d.WidgetIds).DefaultValue(Enumerable.Empty<string>().ToList());
        }
    }
}
