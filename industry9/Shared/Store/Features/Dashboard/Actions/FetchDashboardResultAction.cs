namespace industry9.Shared.Store.Features.Dashboard.Actions
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
