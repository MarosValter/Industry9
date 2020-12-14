using System.Threading;
using System.Threading.Tasks;
using industry9.DataModel.UI.Documents;
using MongoDB.Driver;

namespace industry9.DataModel.UI.Repositories.Dashboard
{
    public interface IDashboardRepository : IBaseDocumentRepository<DashboardDocument>
    {
        Task<UpdateResult> AddWidgetToDashboard(DashboardWidgetData widget, CancellationToken cancellationToken = default);
        Task<UpdateResult> RemoveWidgetFromDashboard(string dashboardId, string widgetId, CancellationToken cancellationToken = default);
    }
}