using System.Linq;
using Fluxor;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.Widget
{
    public class WidgetFeature : Feature<WidgetState>
    {
        public override string GetName() => "Widget";

        protected override WidgetState GetInitialState()
            => new WidgetState(Enumerable.Empty<IWidgetLite>(), null);
    }
}
