using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class WidgetDetail
        : IWidgetDetail
    {
        public WidgetDetail(
            string id, 
            string name, 
            System.DateTimeOffset created, 
            WidgetType type, 
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> labels, 
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IColumnMapping> columnMappings)
        {
            Id = id;
            Name = name;
            Created = created;
            Type = type;
            Labels = labels;
            ColumnMappings = columnMappings;
        }

        public string Id { get; }

        public string Name { get; }

        public System.DateTimeOffset Created { get; }

        public WidgetType Type { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> Labels { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IColumnMapping> ColumnMappings { get; }
    }
}
