using Fluxor;
using industry9.Shared.Store.Dashboard;

namespace industry9.Shared.Store.AppBar
{
    public static class AppBarReducer
    {
        private const string EnabledBarColor = "orange";

        [ReducerMethod]
        public static AppBarState ReduceSetAppBarAction(AppBarState state, SetAppBarAction action)
            => new AppBarState(action.Title, action.Color);

        [ReducerMethod]
        public static AppBarState ReduceToggleEditModeAction(AppBarState state, ToggleEditModeAction action)
            => new AppBarState(state.Title, action.Enabled ? EnabledBarColor : null);
    }
}
