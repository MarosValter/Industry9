﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    /// <summary>
    /// Represents the operation service of the GetDataSourceDefinitions GraphQL operation
    /// <code>
    /// query GetDataSourceDefinitions {
    ///   dataSourceDefinitions {
    ///     __typename
    ///     ... DataSourceDefinitionLite
    ///     ... on DataSourceDefinition {
    ///       id
    ///     }
    ///   }
    /// }
    /// 
    /// fragment DataSourceDefinitionLite on DataSourceDefinition {
    ///   id
    ///   name
    ///   created
    ///   type
    ///   columns {
    ///     __typename
    ///     ... ExportedColumn
    ///   }
    /// }
    /// 
    /// fragment ExportedColumn on ExportedColumnData {
    ///   name
    ///   valueType
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public interface IGetDataSourceDefinitionsQuery : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IGetDataSourceDefinitionsResult>> ExecuteAsync(global::System.Threading.CancellationToken cancellationToken = default);
        global::System.IObservable<global::StrawberryShake.IOperationResult<IGetDataSourceDefinitionsResult>> Watch(global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}
