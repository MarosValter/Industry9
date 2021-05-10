using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.GraphQL.UI.Base;
using industry9.GraphQL.UI.DataLoaders;

namespace industry9.GraphQL.UI.Types
{
    public class DashboardType : BaseNodeType<DashboardDocument, DashboardDataLoader>
    {
        protected override void Configure(IObjectTypeDescriptor<DashboardDocument> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Name("Dashboard");
        }
    }
}
