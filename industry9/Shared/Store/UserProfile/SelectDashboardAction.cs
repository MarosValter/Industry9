namespace industry9.Shared.Store.UserProfile
{
    public class SelectDashboardAction
    {
        public SelectDashboardAction(IDashboard1 dashboard)
        {
            Dashboard = dashboard;
        }

        public IDashboard1 Dashboard { get; }
    }
}
