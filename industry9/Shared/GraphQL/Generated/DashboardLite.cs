using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DashboardLite
        : IDashboardLite
    {
        public DashboardLite(
            string id, 
            string name, 
            string authorId, 
            System.DateTimeOffset created, 
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> labels)
        {
            Id = id;
            Name = name;
            AuthorId = authorId;
            Created = created;
            Labels = labels;
        }

        public string Id { get; }

        public string Name { get; }

        public string AuthorId { get; }

        public System.DateTimeOffset Created { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> Labels { get; }
    }
}
