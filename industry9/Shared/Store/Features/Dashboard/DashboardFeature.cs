using System.Linq;
using Fluxor;
using industry9.Shared.Store.Base;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Dashboard
{
    public class DashboardFeature : Feature<DashboardState>, IHistoryFeature
    {
        public override string GetName() => "Dashboard";

        protected override DashboardState GetInitialState()
            => new DashboardState(Enumerable.Empty<IDashboardLite>(), null);
    }
}
