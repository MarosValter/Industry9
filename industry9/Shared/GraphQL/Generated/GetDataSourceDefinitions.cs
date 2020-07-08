using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetDataSourceDefinitions
        : IGetDataSourceDefinitions
    {
        public GetDataSourceDefinitions(
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IDataSourceDefinitionLite> dataSourceDefinitions)
        {
            DataSourceDefinitions = dataSourceDefinitions;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IDataSourceDefinitionLite> DataSourceDefinitions { get; }
    }
}
