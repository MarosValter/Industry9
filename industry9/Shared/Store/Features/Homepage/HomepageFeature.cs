using Fluxor;
using industry9.Shared.Dto.Dashboard;
using industry9.Shared.Store.Base;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Homepage
{
    public class HomepageFeature : Feature<HomepageState>//, IHistoryFeature
    {
        public override string GetName() => "Homepage";
        protected override HomepageState GetInitialState() => new HomepageState(false, new DashboardData());
    }
}
