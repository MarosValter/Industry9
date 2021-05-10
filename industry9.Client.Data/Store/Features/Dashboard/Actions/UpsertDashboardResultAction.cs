using industry9.Client.Data.Dto.Dashboard;

namespace industry9.Client.Data.Store.Features.Dashboard.Actions
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
