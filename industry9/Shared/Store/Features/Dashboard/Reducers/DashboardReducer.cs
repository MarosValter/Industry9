using System.Linq;
using Fluxor;
using industry9.Shared.Dto.Dashboard;
using industry9.Shared.Dto.DashboardWidget;
using industry9.Shared.Store.Features.Dashboard.Actions;
using industry9.Shared.Store.Features.Widget.Effects;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Dashboard.Reducers
{
    public static class DashboardReducer
    {
        [ReducerMethod]
        public static DashboardState ReduceFetchDashboardsResultAction(
            DashboardState state, FetchDashboardsResultAction action)
            => new DashboardState(action.Dashboards, state.EditedDashboard);

        [ReducerMethod]
        public static DashboardState ReduceUpsertDashboardsResultAction(
            DashboardState state, UpsertDashboardResultAction action)
            => new DashboardState(state.Dashboards, action.Dashboard);

        [ReducerMethod]
        public static DashboardState ReduceToggleEditModeAction(
            DashboardState state, ToggleEditModeAction action)
        => new DashboardState(state.Dashboards, action.Enabled ? state.EditedDashboard : null);

        //TODO automapper
        public static DashboardData MapDashboard(IDashboardDetail dashboard)
        {
            return new DashboardData(dashboard.Id, dashboard.Name, dashboard.ColumnCount,
                dashboard.Private, dashboard.AuthorId, dashboard.Created.DateTime,
                dashboard.Labels.ToList(), dashboard.Widgets.Select(x => MapDashboardWidget(dashboard.Id, x)).ToList());
        }

        //TODO automapper
        public static DashboardWidgetData MapDashboardWidget(string dashboardId, IDashboardWidget widget)
        {
            return new DashboardWidgetData
            {
                DashboardId = dashboardId,
                WidgetId = widget.WidgetId,
                Widget = InitWidgetActionEffect.MapWidget(widget.Widget),
                Position = new PositionData(widget.Position.X, widget.Position.Y),
                Size = new SizeData(widget.Size.Width, widget.Size.Height)
            };
        }
    }
}
