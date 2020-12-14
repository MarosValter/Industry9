namespace industry9.Shared.Store.Features.Dashboard.Actions
{
    public class DeleteDashboardWidgetAction
    {
        public string DashboardId { get; }
        public string WidgetId { get; }

        public DeleteDashboardWidgetAction(string dashboardId, string widgetId)
        {
            DashboardId = dashboardId;
            WidgetId = widgetId;
        }
    }
}
