using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Store.Features.WidgetSource.Actions;

namespace industry9.Client.Data.Store.Features.WidgetSource.Effects
{
    public class ReloadWidgetActionEffect : Effect<ReloadWidgetAction>
    {
        private readonly Iindustry9Client _client;

        public ReloadWidgetActionEffect(Iindustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(ReloadWidgetAction action, IDispatcher dispatcher)
        {
            // TODO
        }
    }
}
