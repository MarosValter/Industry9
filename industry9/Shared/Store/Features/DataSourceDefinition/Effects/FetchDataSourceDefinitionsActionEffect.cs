using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Base;
using industry9.Shared.Store.Extensions;
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
            if (!result.HasErrors && result.Data != null)
            {
                dispatcher.Dispatch(new FetchDataSourceDefinitionsResultAction(result.Data.DataSourceDefinitions));
            }
            else
            {
                result.DispatchToast(dispatcher, null, "Unable to fetch DataSource definitions");
            }
        }
    }
}
