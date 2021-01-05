﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DashboardDetail
        : IDashboardDetail
    {
        public DashboardDetail(
            string id, 
            string name, 
            bool @private, 
            int columnCount, 
            string authorId, 
            System.DateTimeOffset created, 
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> labels, 
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IDashboardWidget> widgets)
        {
            Id = id;
            Name = name;
            Private = @private;
            ColumnCount = columnCount;
            AuthorId = authorId;
            Created = created;
            Labels = labels;
            Widgets = widgets;
        }

        public string Id { get; }

        public string Name { get; }

        public bool Private { get; }

        public int ColumnCount { get; }

        public string AuthorId { get; }

        public System.DateTimeOffset Created { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> Labels { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IDashboardWidget> Widgets { get; }
    }
}
