using System;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Features.DataSourceDefinition.Actions;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Effects
{
    public class EditDataSourceDefinitionActionEffect : Effect<UpsertDataSourceDefinitionAction>
    {
        private readonly IIndustry9Client _client;

        public EditDataSourceDefinitionActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(UpsertDataSourceDefinitionAction action, IDispatcher dispatcher)
        {
            var definition = string.IsNullOrEmpty(action.Id)
                ? new DataSourceDefinitionDetail(null, DateTimeOffset.MinValue, DataSourceType.Random, Enumerable.Empty<string>().ToList())
                : (await _client.GetDataSourceDefinitionAsync(action.Id)).Data.DataSourceDefinition;

            var result = new UpsertDataSourceDefinitionResultAction(definition);
            dispatcher.Dispatch(result);
        }
    }
}
