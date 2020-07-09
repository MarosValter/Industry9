using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Features.DataSourceDefinition.Actions;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Effects
{
    public class FetchDataSourceDefinitionsActionEffect : Effect<FetchDataSourceDefinitionsAction>
    {
        private readonly IIndustry9Client _client;

        public FetchDataSourceDefinitionsActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(FetchDataSourceDefinitionsAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetDataSourceDefinitionsAsync();
            dispatcher.Dispatch(new FetchDataSourceDefinitionsResultAction(result.Data.DataSourceDefinitions));
        }
    }
}
