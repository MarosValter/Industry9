using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertWidget
        : IUpsertWidget
    {
        public UpsertWidget(
            global::industry9.Shared.IWidgetId createWidget)
        {
            CreateWidget = createWidget;
        }

        public global::industry9.Shared.IWidgetId CreateWidget { get; }
    }
}
