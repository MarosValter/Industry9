namespace industry9.Shared.Store.UserProfile
{
    public class SelectDashboardAction
    {
        public SelectDashboardAction(IDashboardLite dashboard)
        {
            Dashboard = dashboard;
        }

        public IDashboardLite Dashboard { get; }
    }
}
