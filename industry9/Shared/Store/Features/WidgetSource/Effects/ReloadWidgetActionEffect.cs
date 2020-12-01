using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Features.WidgetSource.Actions;

namespace industry9.Shared.Store.Features.WidgetSource.Effects
{
    public class ReloadWidgetActionEffect : Effect<ReloadWidgetAction>
    {
        private readonly IIndustry9Client _client;

        public ReloadWidgetActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(ReloadWidgetAction action, IDispatcher dispatcher)
        {
            // TODO
        }
    }
}
