﻿using System.Collections.Generic;
using System.Linq;
using Fluxor;
using industry9.Client.Data.Dto;
using industry9.Client.Data.Dto.Dashboard;
using industry9.Client.Data.Dto.DashboardWidget;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Features.Dashboard.Actions;
using industry9.Client.Data.Store.Features.Widget.Effects;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.Dashboard.Reducers
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
            => new DashboardState(state.Dashboards, action.SaveChanges ? null : action.Dashboard);

        [ReducerMethod]
        public static DashboardState ReduceToggleEditModeAction(
            DashboardState state, ToggleEditModeAction action)
        => new DashboardState(state.Dashboards, action.Enabled ? state.EditedDashboard : null);

        //TODO automapper
        public static DashboardData MapDashboard(IDashboardDetail dashboard)
        {
            return new DashboardData(dashboard.Id, dashboard.Name, dashboard.ColumnCount,
                dashboard.Private, dashboard.AuthorId, dashboard.Created.DateTime,
                dashboard.Labels?.Select(MapLabel).ToList() ?? new List<LabelData>(),
                dashboard.Widgets?.Select(x => MapDashboardWidget(dashboard.Id, x)).ToList()
                ?? new List<DashboardWidgetData>());
        }

        //TODO automapper
        public static DashboardWidgetData MapDashboardWidget(string dashboardId, IDashboardWidget widget)
        {
            return new DashboardWidgetData
            {
                DashboardId = dashboardId,
                WidgetId = widget.Widget.Id,
                Widget = InitWidgetActionEffect.MapWidget(widget.Widget),
                //Position = new PositionData(widget.Position.X, widget.Position.Y),
                //Size = new SizeData(widget.Size.Width, widget.Size.Height)
            };
        }

        //TODO automapper
        public static LabelData MapLabel(ILabel label)
        {
            return new LabelData(label.Name);
        }
    }
}
