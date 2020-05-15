using Fluxor;
using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.AppBar
{
    public class AppBarFeature : Feature<AppBarState>, IHistoryFeature
    {
        public int HistoryLength { get; } = 5;
        public override string GetName() => "AppBar";
        protected override AppBarState GetInitialState() => new AppBarState(null, null);
    }
}
