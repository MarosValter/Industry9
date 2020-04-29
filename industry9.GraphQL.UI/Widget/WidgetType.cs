using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.GraphQL.UI.Base;

namespace industry9.GraphQL.UI.Widget
{
    public class WidgetType : BaseDocumentType<WidgetDocument>
    {
        protected override void Configure(IObjectTypeDescriptor<WidgetDocument> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name("Widget");
        }
    }
}
