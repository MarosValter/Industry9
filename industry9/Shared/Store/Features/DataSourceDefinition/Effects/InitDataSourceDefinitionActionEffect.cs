using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Dto.DataSourceDefinition;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.DataSourceDefinition.Actions;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Effects
{
    public class InitDataSourceDefinitionActionEffect : Effect<InitDataSourceDefinitionAction>
    {
        private readonly IIndustry9Client _client;

        public InitDataSourceDefinitionActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(InitDataSourceDefinitionAction action, IDispatcher dispatcher)
        {
            if (string.IsNullOrEmpty(action.Id))
            {
                dispatcher.Dispatch(new UpsertDataSourceDefinitionResultAction(new DataSourceDefinitionData()));
                return;
            }

            var result = await _client.GetDataSourceDefinitionAsync(action.Id);
            if (!result.HasErrors && result.Data != null)
            {
                var resultAction = new UpsertDataSourceDefinitionResultAction(Map(result.Data.DataSourceDefinition));
                dispatcher.Dispatch(resultAction);
            }
            else
            {
                result.DispatchToast(dispatcher, null, "Unable to fetch DataSource definition");
            }
        }

        private DataSourceDefinitionData Map(IDataSourceDefinitionDetail definition)
        {
            return new DataSourceDefinitionData
            {
                Id = definition.Id,
                Created = definition.Created.DateTime,
                Name = definition.Name,
                Type = definition.Type,
                Inputs = definition.Inputs.ToList()
            };
        }
    }
}
