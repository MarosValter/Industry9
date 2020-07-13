using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.Widget.Actions;

namespace industry9.Shared.Store.Features.Widget.Effects
{
    public class DeleteWidgetActionEffect : Effect<DeleteWidgetAction>
    {
        private readonly IIndustry9Client _client;

        public DeleteWidgetActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(DeleteWidgetAction action, IDispatcher dispatcher)
        {
            var result = await _client.DeleteWidgetAsync(action.Id);
            if (!result.HasErrors && result.Data?.DeleteWidget == true)
            {
                dispatcher.Dispatch(new FetchWidgetsAction());
            }

            result.DispatchToast(dispatcher, "Widget", CRUDOperation.Delete);
        }
    }
}
