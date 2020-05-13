using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Dashboard
        : IDashboard
    {
        public Dashboard(
            string id, 
            string name, 
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabelData> labels, 
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IWidget> widgets)
        {
            Id = id;
            Name = name;
            Labels = labels;
            Widgets = widgets;
        }

        public string Id { get; }

        public string Name { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabelData> Labels { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IWidget> Widgets { get; }
    }
}
