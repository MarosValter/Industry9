using System.Collections.Generic;
using System.Linq;
using Fluxor;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.WidgetSource
{
    public class WidgetSourceFeature : Feature<WidgetSourceState>
    {
        public override string GetName() => "WidgetSource";

        protected override WidgetSourceState GetInitialState()
        => new WidgetSourceState(new List<ISensorData>().ToLookup(x => string.Empty, v => v));
    }
}
