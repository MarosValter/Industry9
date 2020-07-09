using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Store.Base;
using industry9.Shared.Store.Features.DataSourceDefinition.Actions;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Effects
{
    public class DeleteDataSourceDefinitionActionEffect : Effect<DeleteDataSourceDefinitionAction>
    {
        private readonly IIndustry9Client _client;

        public DeleteDataSourceDefinitionActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(DeleteDataSourceDefinitionAction action, IDispatcher dispatcher)
        {
            var result = await _client.DeleteDataSourceDefinitionAsync(action.Id);
            if (!result.HasErrors && result.Data?.DeleteDataSourceDefinition == true)
            {
                dispatcher.Dispatch(new FetchDataSourceDefinitionsAction());
            }

            result.DispatchToast(dispatcher, "DataSource definition", CRUDOperation.Delete);
        }
    }
}
