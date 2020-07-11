using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class WidgetInput
    {
        public Optional<global::System.Collections.Generic.List<global::industry9.Shared.ColumnMappingDataInput>> ColumnMappings { get; set; }

        public Optional<string> DashboardId { get; set; }

        public Optional<IReadOnlyList<string>> DataSourceIds { get; set; }

        public Optional<string> Id { get; set; }

        public Optional<global::System.Collections.Generic.List<global::industry9.Shared.LabelDataInput>> Labels { get; set; }

        public Optional<string> Name { get; set; }
    }
}
