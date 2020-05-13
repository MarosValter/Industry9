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
        Task<UpdateResult> AddWidgetsToDashboard(string dashboardId, IReadOnlyCollection<string> widgetIds, CancellationToken cancellationToken = default);
    }
}