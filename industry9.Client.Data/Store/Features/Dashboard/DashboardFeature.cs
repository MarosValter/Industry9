using System.Linq;
using Fluxor;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Base;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.Dashboard
{
    public class DashboardFeature : Feature<DashboardState>, IHistoryFeature
    {
        public override string GetName() => "Dashboard";

        protected override DashboardState GetInitialState()
            => new DashboardState(Enumerable.Empty<IDashboardLite>(), null);
    }
}
