using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IDashboardWidget
    {
        string WidgetId { get; }

        global::industry9.Shared.IWidgetDetail Widget { get; }

        global::industry9.Shared.ISize Size { get; }

        global::industry9.Shared.IPosition Position { get; }
    }
}
