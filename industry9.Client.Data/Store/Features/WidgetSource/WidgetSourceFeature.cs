using System.Collections.Generic;
using System.Linq;
using Fluxor;
using industry9.Client.Data.Dto.Message;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.WidgetSource
{
    public class WidgetSourceFeature : Feature<WidgetSourceState>
    {
        public override string GetName() => "WidgetSource";

        protected override WidgetSourceState GetInitialState()
        => new WidgetSourceState(new List<MessageData>().ToLookup(x => string.Empty, v => v));
    }
}
