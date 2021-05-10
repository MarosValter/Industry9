using Fluxor;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.AppBar
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
