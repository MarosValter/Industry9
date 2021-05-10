namespace industry9.Client.Data.Store.Features.UserProfile.Actions
{
    public class SelectDashboardAction
    {
        public SelectDashboardAction(string dashboardId)
        {
            DashboardId = dashboardId;
        }

        public string DashboardId { get; }
    }
}
