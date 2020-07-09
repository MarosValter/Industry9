using Fluxor;
using industry9.Shared.Store.Base;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Dashboard
{
    public class DashboardFeature : Feature<DashboardDetailState>, IHistoryFeature
    {
        public int HistoryLength { get; } = 5;
        public void PersistChanges()
        {
            
        }

        public override string GetName() => "Dashboard";
        protected override DashboardDetailState GetInitialState() => new DashboardDetailState(false, false, null);
    }
}
