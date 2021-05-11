using System.Linq;
using Fluxor;
using industry9.Client.Data.Dto;
using industry9.Client.Data.Dto.Dashboard;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Features.Dashboard.Actions;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.Dashboard.Reducers
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

        //TODO automapper
        public static LabelData MapLabel(ILabel label)
        {
            return new LabelData(label.Name);
        }
    }
}
