using System.Linq;
using Fluxor;
using industry9.Shared.Dto.Dashboard;
using industry9.Shared.Store.Features.Dashboard.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Dashboard.Reducers
{
    public class LabelReducer
    {
        [ReducerMethod]
        public static DashboardState ReduceAddLabelAction(DashboardState state, AddLabelAction action)
            => new DashboardState(state.Dashboards, new DashboardData(
                state.EditedDashboard.Id, state.EditedDashboard.Name,
                state.EditedDashboard.ColumnCount, state.EditedDashboard.Private,
                state.EditedDashboard.AuthorId, state.EditedDashboard.Created,
                state.EditedDashboard.Labels.Concat(new[] {action.Label}).ToList(),
                state.EditedDashboard.Widgets));

        [ReducerMethod]
        public static DashboardState ReduceRemoveLabelAction(DashboardState state, RemoveLabelAction action)
            => new DashboardState(state.Dashboards, new DashboardData(
                state.EditedDashboard.Id, state.EditedDashboard.Name,
                state.EditedDashboard.ColumnCount, state.EditedDashboard.Private,
                state.EditedDashboard.AuthorId, state.EditedDashboard.Created,
                state.EditedDashboard.Labels.Where(l => l.Name != action.LabelName).ToList(),
                state.EditedDashboard.Widgets));
    }
}
