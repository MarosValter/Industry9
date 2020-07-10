using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DataSourceDefinitionLite
        : IDataSourceDefinitionLite
    {
        public DataSourceDefinitionLite(
            string id, 
            string name, 
            System.DateTimeOffset created, 
            DataSourceType type)
        {
            Id = id;
            Name = name;
            Created = created;
            Type = type;
        }

        public string Id { get; }

        public string Name { get; }

        public System.DateTimeOffset Created { get; }

        public DataSourceType Type { get; }
    }
}
