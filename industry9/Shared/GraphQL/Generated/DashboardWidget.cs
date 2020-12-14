using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DashboardWidget
        : IDashboardWidget
    {
        public DashboardWidget(
            string widgetId, 
            global::industry9.Shared.IWidgetDetail widget, 
            global::industry9.Shared.ISize size, 
            global::industry9.Shared.IPosition position)
        {
            WidgetId = widgetId;
            Widget = widget;
            Size = size;
            Position = position;
        }

        public string WidgetId { get; }

        public global::industry9.Shared.IWidgetDetail Widget { get; }

        public global::industry9.Shared.ISize Size { get; }

        public global::industry9.Shared.IPosition Position { get; }
    }
}
