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
    public class WidgetQueries
    {
        //[UsePaging]
        //[UseSorting]
        //[UseFiltering]
        public IExecutable<WidgetDocument> GetWidgets([Service] IMongoCollection<WidgetDocument> collection)
        {
            return collection.AsExecutable();
        }

        public Task<WidgetDocument> GetWidget([ID(nameof(WidgetDocument))] string id, WidgetDataLoader loader, CancellationToken token)
        {
            return loader.LoadAsync(id, token);
        }
    }
}
