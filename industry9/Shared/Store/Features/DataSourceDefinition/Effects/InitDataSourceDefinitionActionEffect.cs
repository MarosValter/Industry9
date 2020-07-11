using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Dto.DataSourceDefinition;
using industry9.Shared.Dto.DataSourceDefinition.Properties;
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
                var definition = Map(result.Data.DataSourceDefinition);
                var properties = await FetchProperties(definition.Id, definition.Type);
                definition.Properties = properties;
                var resultAction = new UpsertDataSourceDefinitionResultAction(definition);
                dispatcher.Dispatch(resultAction);
            }
            else
            {
                result.DispatchToast(dispatcher, null, "Unable to fetch DataSource definition");
            }
        }

        // TODO automapper
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

        private async Task<IDataSourcePropertiesData> FetchProperties(string id, DataSourceType type)
        {
            switch (type)
            {
                case DataSourceType.Random:
                    return MapProperties((await _client.FetchRandomDataSourcePropertiesAsync(id))
                        .Data?.FetchRandomPropertiesFromDataSource);
                case DataSourceType.Dataquery:
                    return MapProperties((await _client.FetchQueryDataSourcePropertiesAsync(id))
                        .Data?.FetchDataQueryPropertiesFromDataSource);
                default:
                    return null;
            }
        }

        private IDataSourcePropertiesData MapProperties(IRandomDataSourceProperties properties)
        {
            if (properties == null)
            {
                return null;
            }

            return new RandomDataSourcePropertiesData
            {
                Min = properties.Min,
                Max = properties.Max
            };
        }

        private IDataSourcePropertiesData MapProperties(IDataQueryDataSourceProperties properties)
        {
            if (properties == null)
            {
                return null;
            }

            return new QueryDataSourcePropertiesData
            {
                Query = properties.Query
            };
        }
    }
}
