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
        public static HomepageState ReduceAddLabelAction(HomepageState state, AddLabelAction action)
            => new HomepageState(state.IsLoading, state.EditMode,
                new DashboardData(state.Dashboard.Id, state.Dashboard.Name,
                    state.Dashboard.ColumnCount, state.Dashboard.Private,
                    state.Dashboard.AuthorId, state.Dashboard.Created,
                    state.Dashboard.Labels.Concat(new[] { action.Label }).ToList(),
                    state.Dashboard.Widgets));

        [ReducerMethod]
        public static HomepageState ReduceRemoveLabelAction(HomepageState state, RemoveLabelAction action)
            => new HomepageState(state.IsLoading, state.EditMode,
                new DashboardData(state.Dashboard.Id, state.Dashboard.Name,
                    state.Dashboard.ColumnCount, state.Dashboard.Private,
                    state.Dashboard.AuthorId, state.Dashboard.Created,
                    state.Dashboard.Labels.Where(l => l.Name != action.LabelName).ToList(),
                    state.Dashboard.Widgets));
    }
}
