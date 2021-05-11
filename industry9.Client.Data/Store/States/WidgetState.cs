using System.Collections.Generic;
using System.Linq;
using industry9.Client.Data.Dto.Widget;
using industry9.Client.Data.GraphQL.Generated;

namespace industry9.Client.Data.Store.States
{
    public class WidgetState
    {
        public IEnumerable<IWidgetLite> Widgets { get; }
        public WidgetData EditedObject { get; }

        public WidgetState(IEnumerable<IWidgetLite> widgets, WidgetData editedObject)
        {
            Widgets = widgets ?? Enumerable.Empty<IWidgetLite>();
            EditedObject = editedObject ?? new WidgetData();
        }
    }
}
