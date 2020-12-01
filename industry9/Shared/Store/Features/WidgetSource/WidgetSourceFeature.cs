using System;
using System.Collections.Generic;
using Fluxor;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.WidgetSource
{
    public class WidgetSourceFeature : Feature<WidgetSourceState>
    {
        public override string GetName() => "WidgetSource";

        protected override WidgetSourceState GetInitialState()
        => new WidgetSourceState(new WidgetDetail(null, null, DateTimeOffset.Now, WidgetType.Barchart, new List<ILabel>(), new List<IColumnMapping>()), new List<ISensorData>());
    }
}
