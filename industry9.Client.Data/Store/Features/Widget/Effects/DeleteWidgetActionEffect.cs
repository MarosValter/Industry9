using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.Widget.Actions;
using industry9.Common.Enums;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.Widget.Effects
{
    public class DeleteWidgetActionEffect : Effect<DeleteWidgetAction>
    {
        private readonly Iindustry9Client _client;

        public DeleteWidgetActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(DeleteWidgetAction action, IDispatcher dispatcher)
        {
            var result = await _client.DeleteWidget.ExecuteAsync(action.Id);
            if (result.IsSuccessResult() && result.Data?.DeleteWidget == true)
            {
                dispatcher.Dispatch(new FetchWidgetsAction());
            }

            result.DispatchToast(dispatcher, "Widget", CRUDOperation.Delete);
        }
    }
}
