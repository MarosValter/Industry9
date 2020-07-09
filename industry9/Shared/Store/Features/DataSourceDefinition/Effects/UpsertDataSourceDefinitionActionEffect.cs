using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Store.Base;
using industry9.Shared.Store.Features.DataSourceDefinition.Actions;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Effects
{
    public class UpsertDataSourceDefinitionActionEffect : Effect<UpsertDataSourceDefinitionResultAction>
    {
        private readonly IIndustry9Client _client;

        public UpsertDataSourceDefinitionActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(UpsertDataSourceDefinitionResultAction action, IDispatcher dispatcher)
        {
            if (!action.SaveChanges)
            {
                return;
            }

            var input = CreateInput(action.DataSourceDefinition);
            var result = await _client.UpsertDataSourceDefinitionAsync(input);

            if (!result.HasErrors)
            {
                dispatcher.Dispatch(new FetchDataSourceDefinitionsAction());
            }

            result.DispatchToast(dispatcher, "DataSource definition", string.IsNullOrEmpty(action.DataSourceDefinition.Id) ? CRUDOperation.Create : CRUDOperation.Update);
        }

        private DataSourceDefinitionInput CreateInput(IDataSourceDefinitionDetail definition)
        {
            var input = new DataSourceDefinitionInput
            {
                Type = definition.Type,
                Inputs = definition.Inputs.ToList()
            };

            return input;
        }
    }
}
