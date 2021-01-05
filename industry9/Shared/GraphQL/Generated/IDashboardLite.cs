using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IDashboardLite
    {
        string Id { get; }

        string Name { get; }

        bool Private { get; }

        string AuthorId { get; }

        System.DateTimeOffset Created { get; }

        global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> Labels { get; }
    }
}
