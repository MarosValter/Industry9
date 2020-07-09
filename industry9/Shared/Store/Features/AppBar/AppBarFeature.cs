using Fluxor;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.AppBar
{
    public class AppBarFeature : Feature<AppBarState>//, IHistoryFeature
    {
        //public int HistoryLength { get; } = 5;
        //public void PersistChanges()
        //{
        //    // TODO persist via effect
            
        //}

        public override string GetName() => "AppBar";
        protected override AppBarState GetInitialState() => new AppBarState(null, null);
    }
}
