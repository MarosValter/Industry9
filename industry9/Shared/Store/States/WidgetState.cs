using System;
using System.Collections.Generic;
using System.Text;

namespace industry9.Shared.Store.States
{
    public class WidgetState
    {
        public IEnumerable<IWidgetLite> Widgets { get; }
        public IWidgetDetail EditedObject { get; }

        public WidgetState(IEnumerable<IWidgetLite> widgets, IWidgetDetail editedObject)
        {
            Widgets = widgets;
            EditedObject = editedObject;
        }
    }
}
