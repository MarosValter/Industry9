using System.Collections.ObjectModel;
using System.Linq;
using Fluxor;
using industry9.Shared.Store.Features.Dashboard.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Dashboard.Reducers
{
    public class LabelReducer
    {
        [ReducerMethod]
        public static HomepageState ReduceAddLabelAction(HomepageState state, AddLabelAction action)
            => new HomepageState(state.IsLoading, state.EditMode,
                new DashboardDetail(state.Dashboard.Id, state.Dashboard.Name,
                    state.Dashboard.AuthorId, state.Dashboard.Created,
                    new ReadOnlyCollection<ILabel>(state.Dashboard.Labels.Concat(new[] { action.Label }).ToList()),
                    state.Dashboard.Widgets));

        [ReducerMethod]
        public static HomepageState ReduceRemoveLabelAction(HomepageState detailState, RemoveLabelAction action)
            => new HomepageState(detailState.IsLoading, detailState.EditMode,
                new DashboardDetail(detailState.Dashboard.Id, detailState.Dashboard.Name,
                    detailState.Dashboard.AuthorId, detailState.Dashboard.Created,
                    new ReadOnlyCollection<ILabel>(detailState.Dashboard.Labels.Where(l => l.Name != action.LabelName).ToList()),
                    detailState.Dashboard.Widgets));
    }
}
