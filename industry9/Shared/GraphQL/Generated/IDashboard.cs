using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IDashboard
    {
        string Id { get; }

        string Name { get; }

        global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabelData> Labels { get; }

        global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IWidget> Widgets { get; }
    }
}
