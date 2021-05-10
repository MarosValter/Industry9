using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using industry9.DataModel.UI.Documents;
using industry9.GraphQL.UI.DataLoaders;
using MongoDB.Driver;

namespace industry9.GraphQL.UI.Queries
{
    [ExtendObjectType("Query")]
    public class DashboardQueries
    {
        //[UsePaging]
        //[UseSorting]
        //[UseFiltering]
        public IExecutable<DashboardDocument> GetDashboards([Service] IMongoCollection<DashboardDocument> collection)
        {
            return collection.AsExecutable();
        }

        //[UseFirstOrDefault]
        public Task<DashboardDocument> GetDashboard([ID(nameof(DashboardDocument))] string id, DashboardDataLoader loader, CancellationToken token)
        {
            return loader.LoadAsync(id, token);
        }
    }
}
