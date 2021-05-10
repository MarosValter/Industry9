using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.DataSourceDefinition.Actions;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.DataSourceDefinition.Effects
{
    public class FetchDataSourceDefinitionsActionEffect : Effect<FetchDataSourceDefinitionsAction>
    {
        private readonly Iindustry9Client _client;

        public FetchDataSourceDefinitionsActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(FetchDataSourceDefinitionsAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetDataSourceDefinitions.ExecuteAsync();
            if (result.IsSuccessResult() && result.Data != null)
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
