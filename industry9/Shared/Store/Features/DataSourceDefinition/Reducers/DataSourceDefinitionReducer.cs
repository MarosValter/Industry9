using Fluxor;
using industry9.Shared.Store.Features.DataSourceDefinition.Actions;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Reducers
{
    public class DataSourceDefinitionReducer
    {
        [ReducerMethod]
        public static DataSourceDefinitionState ReduceFetchDataSourceDefinitionsResultAction(
            DataSourceDefinitionState state, FetchDataSourceDefinitionsResultAction action)
            => new DataSourceDefinitionState(action.Definitions, state.EditedDefinition);

        [ReducerMethod]
        public static DataSourceDefinitionState ReduceUpsertDataSourceDefinitionsResultAction(
            DataSourceDefinitionState state, UpsertDataSourceDefinitionResultAction action)
            => new DataSourceDefinitionState(state.Definitions, action.DataSourceDefinition);
    }
}
