using industry9.Shared.Dto.Dashboard;

namespace industry9.Shared.Store.Features.Homepage.Actions
{
    public class FetchDashboardResultAction
    {
        public DashboardData Dashboard { get; }

        public FetchDashboardResultAction(DashboardData dashboard)
        {
            Dashboard = dashboard;
        }
    }
}
