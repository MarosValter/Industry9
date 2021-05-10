using industry9.Client.Data.Dto.DashboardWidget;

namespace industry9.Client.Data.Store.Features.Dashboard.Actions
{
    public class UpsertDashboardWidgetResultAction
    {
        public bool SaveChanges { get; }
        public bool New { get; }

        public DashboardWidgetData DashboardWidget { get; }

        public UpsertDashboardWidgetResultAction(DashboardWidgetData dashboardWidget, bool saveChanges = false, bool @new = false)
        {
            DashboardWidget = dashboardWidget;
            SaveChanges = saveChanges;
            New = @new;
        }
    }
}
