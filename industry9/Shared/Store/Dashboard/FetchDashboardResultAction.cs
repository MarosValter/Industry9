namespace industry9.Shared.Store.Dashboard
{
    public class FetchDashboardResultAction
    {
        public IDashboardDetail Dashboard { get; }

        public FetchDashboardResultAction(IDashboardDetail dashboard)
        {
            Dashboard = dashboard;
        }
    }
}
