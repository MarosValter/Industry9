namespace industry9.Shared.Store.Dashboard
{
    public class FetchDashboardResultAction
    {
        public IDashboard Dashboard { get; }

        public FetchDashboardResultAction(IDashboard dashboard)
        {
            Dashboard = dashboard;
        }
    }
}
