using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Dto.DataSourceDefinition;
using industry9.Shared.Dto.DataSourceDefinition.Properties;
using industry9.Shared.Store.Extensions;
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
                await AssignProperties(result.Data?.UpsertDataSourceDefinition, action.DataSourceDefinition.Type, action.DataSourceDefinition.Properties);
                dispatcher.Dispatch(new FetchDataSourceDefinitionsAction());
            }

            result.DispatchToast(dispatcher, "DataSource definition", string.IsNullOrEmpty(action.DataSourceDefinition.Id) ? CRUDOperation.Create : CRUDOperation.Update);
        }

        private async Task<bool> AssignProperties(string id, DataSourceType type, IDataSourcePropertiesData properties)
        {
            var result = type switch
            {
                DataSourceType.Random => (await _client.AssignRandomDataSourcePropertiesAsync(id,
                    CreatePropertiesInput(properties as RandomDataSourcePropertiesData))).Data
                ?.AssignRandomPropertiesToDataSource ?? false,
                DataSourceType.Dataquery => (await _client.AssignQueryDataSourcePropertiesAsync(id,
                    CreatePropertiesInput(properties as QueryDataSourcePropertiesData))).Data
                ?.AssignDataQueryPropertiesToDataSource ?? false,
                _ => false
            };

            return result;
        }

        // TODO automapper
        private static DataSourceDefinitionInput CreateInput(DataSourceDefinitionData definition)
        {
            var input = new DataSourceDefinitionInput
            {
                Id = definition.Id,
                Name = definition.Name,
                Type = definition.Type,
                Inputs = definition.Inputs.ToList()
            };

            return input;
        }

        // TODO automapper
        private static RandomDataSourcePropertiesInput CreatePropertiesInput(RandomDataSourcePropertiesData properties)
        {
            return new RandomDataSourcePropertiesInput
            {
                Min = properties.Min,
                Max = properties.Max
            };
        }

        // TODO automapper
        private static DataQueryDataSourcePropertiesInput CreatePropertiesInput(QueryDataSourcePropertiesData properties)
        {
            return new DataQueryDataSourcePropertiesInput
            {
                Query = properties.Query
            };
        }
    }
}
