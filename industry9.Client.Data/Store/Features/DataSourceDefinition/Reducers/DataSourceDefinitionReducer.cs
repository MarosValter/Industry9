using System.Linq;
using Fluxor;
using industry9.Client.Data.Dto.DataSourceDefinition;
using industry9.Client.Data.Store.Features.DataSourceDefinition.Actions;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.DataSourceDefinition.Reducers
{
    public class DataSourceDefinitionReducer
    {
        [ReducerMethod]
        public static DataSourceDefinitionState ReduceFetchDataSourceDefinitionsResultAction(
            DataSourceDefinitionState state, FetchDataSourceDefinitionsResultAction action)
            => new DataSourceDefinitionState(action.Definitions, state.EditedObject);

        [ReducerMethod]
        public static DataSourceDefinitionState ReduceUpsertDataSourceDefinitionsResultAction(
            DataSourceDefinitionState state, UpsertDataSourceDefinitionResultAction action)
            => new DataSourceDefinitionState(state.Definitions, action.DataSourceDefinition);

        //TODO automapper
        //private static IExportedColumn MapColumn(ExportedColumnData column)
        //{
        //    return new ExportedColumn(column.Name, column.ValueType);
        //}
    }
}
