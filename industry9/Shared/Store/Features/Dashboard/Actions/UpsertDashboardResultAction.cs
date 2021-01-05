using industry9.Shared.Dto.Dashboard;

namespace industry9.Shared.Store.Features.Dashboard.Actions
{
    public class UpsertDashboardResultAction
    {
        public bool SaveChanges { get; }
        public DashboardData Dashboard { get; }

        public UpsertDashboardResultAction(DashboardData dashboard, bool saveChanges = false)
        {
            Dashboard = dashboard;
            SaveChanges = saveChanges;
        }
    }
}
