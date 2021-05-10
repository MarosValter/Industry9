using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.GraphQL.UI.Base;
using industry9.GraphQL.UI.DataLoaders;

namespace industry9.GraphQL.UI.Types
{
    public class WidgetType : BaseNodeType<WidgetDocument, WidgetDataLoader>
    {
        protected override void Configure(IObjectTypeDescriptor<WidgetDocument> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name("Widget");
        }
    }
}
