using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IDataSourceDefinitionDetail
    {
        string Id { get; }

        string Name { get; }

        System.DateTimeOffset Created { get; }

        DataSourceType Type { get; }

        IReadOnlyList<string> Inputs { get; }

        global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IExportedColumn> Columns { get; }
    }
}
