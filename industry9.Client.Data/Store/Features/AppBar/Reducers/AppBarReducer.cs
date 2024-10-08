﻿using Fluxor;
using industry9.Client.Data.Store.Features.AppBar.Actions;
using industry9.Client.Data.Store.Features.Dashboard.Actions;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.AppBar.Reducers
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
