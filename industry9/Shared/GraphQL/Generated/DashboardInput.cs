using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DashboardInput
    {
        public Optional<string> Id { get; set; }

        public Optional<global::System.Collections.Generic.List<global::industry9.Shared.LabelDataInput>> Labels { get; set; }

        public Optional<string> Name { get; set; }

        public Optional<global::System.Collections.Generic.List<global::industry9.Shared.DashboardWidgetInput>> Widgets { get; set; }
    }
}
