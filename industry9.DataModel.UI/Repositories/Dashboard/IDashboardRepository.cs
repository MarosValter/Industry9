using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using industry9.DataModel.UI.Documents;
using MongoDB.Bson;
using MongoDB.Driver;

namespace industry9.DataModel.UI.Repositories.Dashboard
{
    public interface IDashboardRepository : IBaseDocumentRepository<DashboardDocument>
    {
        Task<UpdateResult> AddWidgetsToDashboard(ObjectId dashboardId, IReadOnlyCollection<ObjectId> widgetIds, CancellationToken cancellationToken = default);
    }
}