using industry9.Shared.Dto.DashboardWidget;

namespace industry9.Shared.Store.Features.Dashboard.Actions
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
