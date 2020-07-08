using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetWidget
        : IGetWidget
    {
        public GetWidget(
            global::industry9.Shared.IWidgetDetail widget)
        {
            Widget = widget;
        }

        public global::industry9.Shared.IWidgetDetail Widget { get; }
    }
}
