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
            global::industry9.Shared.IWidgetId widget, 
            string size, 
            string position)
        {
            WidgetId = widgetId;
            Widget = widget;
            Size = size;
            Position = position;
        }

        public string WidgetId { get; }

        public global::industry9.Shared.IWidgetId Widget { get; }

        public string Size { get; }

        public string Position { get; }
    }
}
