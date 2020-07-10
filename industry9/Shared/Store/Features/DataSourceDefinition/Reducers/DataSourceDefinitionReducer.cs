using System;
using System.Linq;
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
            => new DataSourceDefinitionState(action.Definitions, state.EditedObject);

        [ReducerMethod]
        public static DataSourceDefinitionState ReduceUpsertDataSourceDefinitionsResultAction(
            DataSourceDefinitionState state, UpsertDataSourceDefinitionResultAction action)
            => new DataSourceDefinitionState(state.Definitions, new DataSourceDefinitionDetail(
                action.DataSourceDefinition.Id, action.DataSourceDefinition.Name,
                action.DataSourceDefinition.Created, action.DataSourceDefinition.Type,
                action.DataSourceDefinition.Inputs.ToList()));
    }
}
