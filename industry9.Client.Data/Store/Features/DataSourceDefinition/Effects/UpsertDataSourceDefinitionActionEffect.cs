using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Dto.DataSourceDefinition;
using industry9.Client.Data.Dto.DataSourceDefinition.Properties;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.DataSourceDefinition.Actions;
using industry9.Common.Enums;
using StrawberryShake;
using DataSourceType = industry9.Client.Data.GraphQL.Generated.DataSourceType;

namespace industry9.Client.Data.Store.Features.DataSourceDefinition.Effects
{
    public class UpsertDataSourceDefinitionActionEffect : Effect<UpsertDataSourceDefinitionResultAction>
    {
        private readonly Iindustry9Client _client;

        public UpsertDataSourceDefinitionActionEffect(Iindustry9Client client)
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
            var result = await _client.UpsertDataSourceDefinition.ExecuteAsync(input);

            if (result.IsSuccessResult())
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
                DataSourceType.Random => (await _client.AssignRandomDataSourceProperties.ExecuteAsync(id,
                    CreatePropertiesInput(properties as RandomDataSourcePropertiesData))).Data
                ?.AssignRandomPropertiesToDataSource ?? false,
                DataSourceType.DataQuery => (await _client.AssignQueryDataSourceProperties.ExecuteAsync(id,
                    CreatePropertiesInput(properties as QueryDataSourcePropertiesData))).Data
                ?.AssignDataQueryPropertiesToDataSource ?? false,
                _ => false
            };

            return result;
        }

        //TODO automapper
        private static DataSourceDefinitionInput CreateInput(DataSourceDefinitionData definition)
        {
            var input = new DataSourceDefinitionInput
            {
                Id = definition.Id,
                Name = definition.Name,
                Type = definition.Type,
                Inputs = definition.Inputs.ToList(),
                Columns = definition.Columns.Select(MapColumn).ToList()
            };

            return input;
        }

        //TODO automapper
        private static ExportedColumnDataInput MapColumn(ExportedColumnData column)
        {
            return new ExportedColumnDataInput
            {
                Name = column.Name,
                ValueType = column.ValueType
            };
        }

        //TODO automapper
        private static RandomDataSourcePropertiesInput CreatePropertiesInput(RandomDataSourcePropertiesData properties)
        {
            return new RandomDataSourcePropertiesInput
            {
                Min = properties.Min,
                Max = properties.Max
            };
        }

        //TODO automapper
        private static DataQueryDataSourcePropertiesInput CreatePropertiesInput(QueryDataSourcePropertiesData properties)
        {
            return new DataQueryDataSourcePropertiesInput
            {
                Query = properties.Query
            };
        }
    }
}
