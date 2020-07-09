namespace industry9.Shared.Store.Features.UserProfile.Actions
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
