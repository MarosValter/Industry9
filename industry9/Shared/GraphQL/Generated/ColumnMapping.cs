using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ColumnMapping
        : IColumnMapping
    {
        public ColumnMapping(
            string name, 
            string format, 
            string dataSourceId, 
            string sourceColumn)
        {
            Name = name;
            Format = format;
            DataSourceId = dataSourceId;
            SourceColumn = sourceColumn;
        }

        public string Name { get; }

        public string Format { get; }

        public string DataSourceId { get; }

        public string SourceColumn { get; }
    }
}
