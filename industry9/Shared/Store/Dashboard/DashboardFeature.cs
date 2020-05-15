using Fluxor;
using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.Dashboard
{
    public class DashboardFeature : Feature<DashboardState>, IHistoryFeature
    {
        public int HistoryLength { get; } = 5;
        public override string GetName() => "Dashboard";
        protected override DashboardState GetInitialState() => new DashboardState(false, false, null);
    }
}
