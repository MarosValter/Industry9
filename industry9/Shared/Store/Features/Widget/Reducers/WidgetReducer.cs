using Fluxor;
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
            => new WidgetState(state.Widgets, action.Widget);

        ////TODO automapper
        //private static IColumnMapping MapColumn(ColumnMappingData column)
        //{
        //    return new ColumnMapping(column.Name, column.Format, column.DataSourceId, column.SourceColumn);
        //}

        ////TODO automapper
        //static WidgetData MapWidget(IWidgetDetail detail)
        //{
        //    var result = new WidgetData();

        //    if (detail != null)
        //    {
        //        result.Id = detail.Id;
        //        result.Name = detail.Name;
        //        result.Type = detail.Type;
        //        result.Labels = detail.Labels.ToList();
        //        result.ColumnMappings = detail.ColumnMappings.Select(MapColumn).ToList();
        //    }

        //    return result;
        //}

        ////TODO automapper
        //static ColumnMappingData MapColumn(IColumnMapping column)
        //{
        //    return new ColumnMappingData
        //    {
        //        Name = column.Name,
        //        Format = column.Format,
        //        DataSourceId = column.DataSourceId,
        //        SourceColumn = column.SourceColumn
        //    };
        //}
    }
}
