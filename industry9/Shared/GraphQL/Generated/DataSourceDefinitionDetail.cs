using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DataSourceDefinitionDetail
        : IDataSourceDefinitionDetail
    {
        public DataSourceDefinitionDetail(
            string id, 
            System.DateTimeOffset created, 
            DataSourceType type, 
            IReadOnlyList<string> inputs)
        {
            Id = id;
            Created = created;
            Type = type;
            Inputs = inputs;
        }

        public string Id { get; }

        public System.DateTimeOffset Created { get; }

        public DataSourceType Type { get; }

        public IReadOnlyList<string> Inputs { get; }
    }
}
