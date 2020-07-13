using System.Linq;
using Fluxor;
using industry9.Shared.Dto.Widget;
using industry9.Shared.Store.Features.Widget.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Widget.Reducers
{
    public class WidgetReducer
    {
        [ReducerMethod]
        public static WidgetState ReduceFetchWidgetsResultAction(
            WidgetState state, FetchWidgetsResultAction action)
            => new WidgetState(action.Widgets, state.EditedObject);

        [ReducerMethod]
        public static WidgetState ReduceUpsertWidgetsResultAction(
            WidgetState state, UpsertWidgetResultAction action)
            => new WidgetState(state.Widgets, new WidgetDetail(
                    action.Widget.Id, action.Widget.Name,
                    action.Widget.Created, action.Widget.Type,
                    action.Widget.Labels.ToList(),
                    action.Widget.ColumnMappings.Select(MapColumn).ToList()));

        //TODO automapper
        private static IColumnMapping MapColumn(ColumnMappingData column)
        {
            return new ColumnMapping(column.Name, column.Format, column.DataSourceId, column.SourceColumn);
        }
    }
}
