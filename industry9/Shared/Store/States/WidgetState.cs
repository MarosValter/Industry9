using System.Collections.Generic;
using System.Linq;
using industry9.Shared.Dto.Widget;

namespace industry9.Shared.Store.States
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
