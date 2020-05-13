using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using industry9.DataModel.UI.Documents;
using MongoDB.Bson;
using MongoDB.Driver;

namespace industry9.DataModel.UI.Repositories.Dashboard
{
    public class DashboardRepository : BaseDocumentRepository<DashboardDocument>, IDashboardRepository
    {
        public DashboardRepository(IMongoCollection<DashboardDocument> collection) : base(collection)
        {
        }

        public async Task<UpdateResult> AddWidgetsToDashboard(string dashboardId, IReadOnlyCollection<string> widgetIds, CancellationToken cancellationToken = default)
        {
            var filter = Builders<DashboardDocument>.Filter.Eq(d => d.Id, dashboardId);
            var update = Builders<DashboardDocument>.Update.AddToSetEach(d => d.WidgetIds, widgetIds);
            return await Collection.UpdateOneAsync(filter, update, null, cancellationToken);
        }
    }
}
