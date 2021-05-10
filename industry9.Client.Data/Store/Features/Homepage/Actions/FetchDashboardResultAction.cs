using industry9.Client.Data.Dto.Dashboard;

namespace industry9.Client.Data.Store.Features.Homepage.Actions
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
