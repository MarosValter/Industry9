using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetWidgets
        : IGetWidgets
    {
        public GetWidgets(
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IWidgetLite> widgets)
        {
            Widgets = widgets;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IWidgetLite> Widgets { get; }
    }
}
