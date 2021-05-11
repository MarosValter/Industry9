using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Dto.DataSourceDefinition;
using industry9.Client.Data.Dto.DataSourceDefinition.Properties;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.DataSourceDefinition.Actions;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.DataSourceDefinition.Effects
{
    public class InitDataSourceDefinitionActionEffect : Effect<InitDataSourceDefinitionAction>
    {
        private readonly Iindustry9Client _client;

        public InitDataSourceDefinitionActionEffect(Iindustry9Client client)
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

            var result = await _client.GetDataSourceDefinition.ExecuteAsync(action.Id);
            if (result.IsSuccessResult() && result.Data != null)
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

        private async Task<IDataSourcePropertiesData> FetchProperties(string id, DataSourceType type)
        {
            return type switch
            {
                DataSourceType.Random => MapProperties((await _client.FetchRandomDataSourceProperties.ExecuteAsync(id))
                                                       .Data?.FetchRandomPropertiesFromDataSource),
                DataSourceType.DataQuery => MapProperties(
                    (await _client.FetchQueryDataSourceProperties.ExecuteAsync(id)).Data
                    ?.FetchDataQueryPropertiesFromDataSource),
                _ => null
            };
        }

        //TODO automapper
        private static DataSourceDefinitionData Map(IDataSourceDefinitionDetail definition)
        {
            return new DataSourceDefinitionData
            {
                Id = definition.Id,
                Created = definition.Created.DateTime,
                Name = definition.Name,
                Type = definition.Type,
                Inputs = definition.Inputs.ToList(),
                Columns = definition.Columns.Select(MapColumn).ToList()
            };
        }

        //TODO automapper
        private static IDataSourcePropertiesData MapProperties(IFetchRandomDataSourceProperties_FetchRandomPropertiesFromDataSource properties)
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

        //TODO automapper
        private static IDataSourcePropertiesData MapProperties(IFetchQueryDataSourceProperties_FetchDataQueryPropertiesFromDataSource properties)
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

        //TODO automapper
        private static ExportedColumnData MapColumn(IExportedColumn column)
        {
            return new ExportedColumnData
            {
                Name = column.Name,
                ValueType = column.ValueType
            };
        }
    }
}
