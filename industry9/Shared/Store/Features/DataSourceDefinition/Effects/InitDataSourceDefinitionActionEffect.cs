using System;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Base;
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
                dispatcher.Dispatch(new UpsertDataSourceDefinitionResultAction(
                    new DataSourceDefinitionDetail(null, DateTimeOffset.MinValue, DataSourceType.Random, 
                        Enumerable.Empty<string>().ToList())));
                return;
            }

            var result = await _client.GetDataSourceDefinitionAsync(action.Id);
            if (!result.HasErrors && result.Data != null)
            {
                var resultAction = new UpsertDataSourceDefinitionResultAction(result.Data.DataSourceDefinition);
                dispatcher.Dispatch(resultAction);
            }
            else
            {
                result.DispatchToast(dispatcher, null, "Unable to fetch DataSource definition");
            }
        }
    }
}
