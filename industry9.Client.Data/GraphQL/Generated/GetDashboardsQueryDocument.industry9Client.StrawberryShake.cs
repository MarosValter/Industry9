﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    /// <summary>
    /// Represents the operation service of the GetDashboards GraphQL operation
    /// <code>
    /// query GetDashboards {
    ///   dashboards {
    ///     __typename
    ///     ... DashboardLite
    ///     ... on Dashboard {
    ///       id
    ///     }
    ///   }
    /// }
    /// 
    /// fragment DashboardLite on Dashboard {
    ///   id
    ///   name
    ///   private
    ///   authorId
    ///   created
    ///   labels {
    ///     __typename
    ///     ... Label
    ///   }
    /// }
    /// 
    /// fragment Label on LabelData {
    ///   name
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetDashboardsQueryDocument : global::StrawberryShake.IDocument
    {
        private GetDashboardsQueryDocument()
        {
        }

        public static GetDashboardsQueryDocument Instance { get; } = new GetDashboardsQueryDocument();
        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Query;
        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{0x71, 0x75, 0x65, 0x72, 0x79, 0x20, 0x47, 0x65, 0x74, 0x44, 0x61, 0x73, 0x68, 0x62, 0x6f, 0x61, 0x72, 0x64, 0x73, 0x20, 0x7b, 0x20, 0x64, 0x61, 0x73, 0x68, 0x62, 0x6f, 0x61, 0x72, 0x64, 0x73, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x2e, 0x2e, 0x2e, 0x20, 0x44, 0x61, 0x73, 0x68, 0x62, 0x6f, 0x61, 0x72, 0x64, 0x4c, 0x69, 0x74, 0x65, 0x20, 0x2e, 0x2e, 0x2e, 0x20, 0x6f, 0x6e, 0x20, 0x44, 0x61, 0x73, 0x68, 0x62, 0x6f, 0x61, 0x72, 0x64, 0x20, 0x7b, 0x20, 0x69, 0x64, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x66, 0x72, 0x61, 0x67, 0x6d, 0x65, 0x6e, 0x74, 0x20, 0x44, 0x61, 0x73, 0x68, 0x62, 0x6f, 0x61, 0x72, 0x64, 0x4c, 0x69, 0x74, 0x65, 0x20, 0x6f, 0x6e, 0x20, 0x44, 0x61, 0x73, 0x68, 0x62, 0x6f, 0x61, 0x72, 0x64, 0x20, 0x7b, 0x20, 0x69, 0x64, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x70, 0x72, 0x69, 0x76, 0x61, 0x74, 0x65, 0x20, 0x61, 0x75, 0x74, 0x68, 0x6f, 0x72, 0x49, 0x64, 0x20, 0x63, 0x72, 0x65, 0x61, 0x74, 0x65, 0x64, 0x20, 0x6c, 0x61, 0x62, 0x65, 0x6c, 0x73, 0x20, 0x7b, 0x20, 0x5f, 0x5f, 0x74, 0x79, 0x70, 0x65, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x2e, 0x2e, 0x2e, 0x20, 0x4c, 0x61, 0x62, 0x65, 0x6c, 0x20, 0x7d, 0x20, 0x7d, 0x20, 0x66, 0x72, 0x61, 0x67, 0x6d, 0x65, 0x6e, 0x74, 0x20, 0x4c, 0x61, 0x62, 0x65, 0x6c, 0x20, 0x6f, 0x6e, 0x20, 0x4c, 0x61, 0x62, 0x65, 0x6c, 0x44, 0x61, 0x74, 0x61, 0x20, 0x7b, 0x20, 0x6e, 0x61, 0x6d, 0x65, 0x20, 0x7d};
        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("md5Hash", "d8cf18cb6ab350ba523106807bb4ffef");
        public override global::System.String ToString()
        {
#if NETSTANDARD2_0
        return global::System.Text.Encoding.UTF8.GetString(Body.ToArray());
#else
            return global::System.Text.Encoding.UTF8.GetString(Body);
#endif
        }
    }
}
