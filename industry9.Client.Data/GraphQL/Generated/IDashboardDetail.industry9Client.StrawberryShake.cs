﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public interface IDashboardDetail
    {
        public global::System.String Id { get; }

        public global::System.String? Name { get; }

        public global::System.Boolean Private { get; }

        public global::System.Int32 ColumnCount { get; }

        public global::System.String? AuthorId { get; }

        public global::System.DateTimeOffset Created { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.IGetDashboard_Dashboard_Labels?>? Labels { get; }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.IGetDashboard_Dashboard_Widgets?>? Widgets { get; }
    }
}
