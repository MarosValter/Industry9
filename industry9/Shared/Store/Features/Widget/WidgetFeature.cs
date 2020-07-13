﻿using System.Linq;
using Fluxor;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Widget
{
    public class WidgetFeature : Feature<WidgetState>
    {
        public override string GetName() => "Widget";

        protected override WidgetState GetInitialState()
            => new WidgetState(Enumerable.Empty<IWidgetLite>(), null);
    }
}
