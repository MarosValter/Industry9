using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using industry9.DataModel.UI.Documents;
using MongoDB.Driver;

namespace industry9.DataModel.UI.Repositories.Dashboard
{
    public class DashboardRepository : BaseDocumentRepository<DashboardDocument>, IDashboardRepository
    {
        public DashboardRepository(IMongoCollection<DashboardDocument> collection) : base(collection)
        {
        }

        public async Task<UpdateResult> AddWidgetToDashboard(DashboardWidgetData widget, CancellationToken cancellationToken = default)
        {
            var filter = Builders<DashboardDocument>.Filter;
            var dashboardFilter = filter.Eq(d => d.Id, widget.DashboardId);
            var widgetFilter = filter.ElemMatch(d => d.Widgets, w => w.WidgetId == widget.WidgetId);

            var result = await Collection.UpdateOneAsync(dashboardFilter & widgetFilter, Builders<DashboardDocument>.Update.Set(d => d.Widgets.ElementAt(-1), widget), new UpdateOptions(), cancellationToken);
            if (result.IsAcknowledged && result.ModifiedCount == 0)
            {
                return await Collection.UpdateOneAsync(dashboardFilter, Builders<DashboardDocument>.Update.AddToSet(d => d.Widgets, widget), new UpdateOptions(), cancellationToken);
            }

            return result;
        }

        public async Task<UpdateResult> RemoveWidgetFromDashboard(string dashboardId, string widgetId, CancellationToken cancellationToken = default)
        {
            var filter = Builders<DashboardWidgetData>.Filter.Eq(d => d.DashboardId, dashboardId) &
                         Builders<DashboardWidgetData>.Filter.Eq(d => d.WidgetId, widgetId);
            var update = Builders<DashboardDocument>.Update.PullFilter(d => d.Widgets, filter);
            return await Collection.UpdateOneAsync(Builders<DashboardDocument>.Filter.Eq(d => d.Id, dashboardId),
                update, new UpdateOptions(), cancellationToken);
        }
    }
}
