using System.Linq;
using Fluxor;
using industry9.Shared.Dto.DataSourceDefinition;
using industry9.Shared.Store.Features.DataSourceDefinition.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Reducers
{
    public class DataSourceDefinitionReducer
    {
        [ReducerMethod]
        public static DataSourceDefinitionState ReduceFetchDataSourceDefinitionsResultAction(
            DataSourceDefinitionState state, FetchDataSourceDefinitionsResultAction action)
            => new DataSourceDefinitionState(action.Definitions, state.EditedObject, state.EditedProperties);

        [ReducerMethod]
        public static DataSourceDefinitionState ReduceUpsertDataSourceDefinitionsResultAction(
            DataSourceDefinitionState state, UpsertDataSourceDefinitionResultAction action)
            => new DataSourceDefinitionState(state.Definitions, new DataSourceDefinitionDetail(
                action.DataSourceDefinition.Id, action.DataSourceDefinition.Name,
                action.DataSourceDefinition.Created, action.DataSourceDefinition.Type,
                action.DataSourceDefinition.Inputs.ToList(),
                action.DataSourceDefinition.Columns.Select(MapColumn).ToList()),
                action.DataSourceDefinition.Properties);

        //TODO automapper
        private static IExportedColumn MapColumn(ExportedColumnData column)
        {
            return new ExportedColumn(column.Name, column.ValueType);
        }
    }
}
