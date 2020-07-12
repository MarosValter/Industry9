using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ExportedColumn
        : IExportedColumn
    {
        public ExportedColumn(
            string name, 
            ColumnValueType valueType)
        {
            Name = name;
            ValueType = valueType;
        }

        public string Name { get; }

        public ColumnValueType ValueType { get; }
    }
}
