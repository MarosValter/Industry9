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
            string name, 
            System.DateTimeOffset created, 
            DataSourceType type, 
            IReadOnlyList<string> inputs, 
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IExportedColumn> columns)
        {
            Id = id;
            Name = name;
            Created = created;
            Type = type;
            Inputs = inputs;
            Columns = columns;
        }

        public string Id { get; }

        public string Name { get; }

        public System.DateTimeOffset Created { get; }

        public DataSourceType Type { get; }

        public IReadOnlyList<string> Inputs { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IExportedColumn> Columns { get; }
    }
}
