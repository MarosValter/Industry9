using System;
using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.Widget.Actions;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.Widget.Effects
{
    public class FetchWidgetsActionEffect : Effect<FetchWidgetsAction>
    {
        private readonly Iindustry9Client _client;

        public FetchWidgetsActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(FetchWidgetsAction action, IDispatcher dispatcher)
        {
            try
            {
                var result = await _client.GetWidgets.ExecuteAsync();
                if (result.IsSuccessResult() && result.Data != null)
                {
                    dispatcher.Dispatch(new FetchWidgetsResultAction(result.Data.Widgets));
                }
                else
                {
                    result.DispatchToast(dispatcher, null, "Unable to fetch Widgets");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
