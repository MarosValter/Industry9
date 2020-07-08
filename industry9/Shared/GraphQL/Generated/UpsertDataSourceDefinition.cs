using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertDataSourceDefinition
        : IUpsertDataSourceDefinition
    {
        public UpsertDataSourceDefinition(
            global::industry9.Shared.IDataSourceDefinitionId createDataSourceDefinition)
        {
            CreateDataSourceDefinition = createDataSourceDefinition;
        }

        public global::industry9.Shared.IDataSourceDefinitionId CreateDataSourceDefinition { get; }
    }
}
