using Fluxor;
using industry9.Client.Data.Dto.Dashboard;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.Homepage
{
    public class HomepageFeature : Feature<HomepageState>//, IHistoryFeature
    {
        public override string GetName() => "Homepage";
        protected override HomepageState GetInitialState() => new HomepageState(false, new DashboardData());
    }
}
