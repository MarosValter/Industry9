﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    /// <summary>
    /// Represents the operation service of the AssignQueryDataSourceProperties GraphQL operation
    /// <code>
    /// mutation AssignQueryDataSourceProperties($definitionId: ID!, $properties: DataQueryDataSourcePropertiesInput!) {
    ///   assignDataQueryPropertiesToDataSource(dataSourceId: $definitionId, properties: $properties)
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class AssignQueryDataSourcePropertiesMutationDocument : global::StrawberryShake.IDocument
    {
        private AssignQueryDataSourcePropertiesMutationDocument()
        {
        }

        public static AssignQueryDataSourcePropertiesMutationDocument Instance { get; } = new AssignQueryDataSourcePropertiesMutationDocument();
        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Mutation;
        public global::System.ReadOnlySpan<global::System.Byte> Body => new global::System.Byte[]{0x6d, 0x75, 0x74, 0x61, 0x74, 0x69, 0x6f, 0x6e, 0x20, 0x41, 0x73, 0x73, 0x69, 0x67, 0x6e, 0x51, 0x75, 0x65, 0x72, 0x79, 0x44, 0x61, 0x74, 0x61, 0x53, 0x6f, 0x75, 0x72, 0x63, 0x65, 0x50, 0x72, 0x6f, 0x70, 0x65, 0x72, 0x74, 0x69, 0x65, 0x73, 0x28, 0x24, 0x64, 0x65, 0x66, 0x69, 0x6e, 0x69, 0x74, 0x69, 0x6f, 0x6e, 0x49, 0x64, 0x3a, 0x20, 0x49, 0x44, 0x21, 0x2c, 0x20, 0x24, 0x70, 0x72, 0x6f, 0x70, 0x65, 0x72, 0x74, 0x69, 0x65, 0x73, 0x3a, 0x20, 0x44, 0x61, 0x74, 0x61, 0x51, 0x75, 0x65, 0x72, 0x79, 0x44, 0x61, 0x74, 0x61, 0x53, 0x6f, 0x75, 0x72, 0x63, 0x65, 0x50, 0x72, 0x6f, 0x70, 0x65, 0x72, 0x74, 0x69, 0x65, 0x73, 0x49, 0x6e, 0x70, 0x75, 0x74, 0x21, 0x29, 0x20, 0x7b, 0x20, 0x61, 0x73, 0x73, 0x69, 0x67, 0x6e, 0x44, 0x61, 0x74, 0x61, 0x51, 0x75, 0x65, 0x72, 0x79, 0x50, 0x72, 0x6f, 0x70, 0x65, 0x72, 0x74, 0x69, 0x65, 0x73, 0x54, 0x6f, 0x44, 0x61, 0x74, 0x61, 0x53, 0x6f, 0x75, 0x72, 0x63, 0x65, 0x28, 0x64, 0x61, 0x74, 0x61, 0x53, 0x6f, 0x75, 0x72, 0x63, 0x65, 0x49, 0x64, 0x3a, 0x20, 0x24, 0x64, 0x65, 0x66, 0x69, 0x6e, 0x69, 0x74, 0x69, 0x6f, 0x6e, 0x49, 0x64, 0x2c, 0x20, 0x70, 0x72, 0x6f, 0x70, 0x65, 0x72, 0x74, 0x69, 0x65, 0x73, 0x3a, 0x20, 0x24, 0x70, 0x72, 0x6f, 0x70, 0x65, 0x72, 0x74, 0x69, 0x65, 0x73, 0x29, 0x20, 0x7d};
        public global::StrawberryShake.DocumentHash Hash { get; } = new global::StrawberryShake.DocumentHash("md5Hash", "d9d75f2732cf921cc265c7f1a809827c");
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
