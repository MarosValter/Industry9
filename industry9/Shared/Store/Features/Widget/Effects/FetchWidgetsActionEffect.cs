using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.Widget.Actions;

namespace industry9.Shared.Store.Features.Widget.Effects
{
    public class FetchWidgetsActionEffect : Effect<FetchWidgetsAction>
    {
        private readonly IIndustry9Client _client;

        public FetchWidgetsActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(FetchWidgetsAction action, IDispatcher dispatcher)
        {
            var result = await _client.GetWidgetsAsync();
            if (!result.HasErrors && result.Data != null)
            {
                dispatcher.Dispatch(new FetchWidgetsResultAction(result.Data.Widgets));
            }
            else
            {
                result.DispatchToast(dispatcher, null, "Unable to fetch Widgets");
            }
        }
    }
}
