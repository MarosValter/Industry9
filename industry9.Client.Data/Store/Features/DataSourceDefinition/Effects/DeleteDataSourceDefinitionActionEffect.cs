using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.DataSourceDefinition.Actions;
using industry9.Common.Enums;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.DataSourceDefinition.Effects
{
    public class DeleteDataSourceDefinitionActionEffect : Effect<DeleteDataSourceDefinitionAction>
    {
        private readonly Iindustry9Client _client;

        public DeleteDataSourceDefinitionActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(DeleteDataSourceDefinitionAction action, IDispatcher dispatcher)
        {
            var result = await _client.DeleteDataSourceDefinition.ExecuteAsync(action.Id);
            if (result.IsSuccessResult() && result.Data?.DeleteDataSourceDefinition == true)
            {
                dispatcher.Dispatch(new FetchDataSourceDefinitionsAction());
            }

            result.DispatchToast(dispatcher, "DataSource definition", CRUDOperation.Delete);
        }
    }
}
