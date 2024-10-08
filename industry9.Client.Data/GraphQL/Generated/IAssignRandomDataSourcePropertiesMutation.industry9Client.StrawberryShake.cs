﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    /// <summary>
    /// Represents the operation service of the AssignRandomDataSourceProperties GraphQL operation
    /// <code>
    /// mutation AssignRandomDataSourceProperties($definitionId: ID!, $properties: RandomDataSourcePropertiesInput!) {
    ///   assignRandomPropertiesToDataSource(dataSourceId: $definitionId, properties: $properties)
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public interface IAssignRandomDataSourcePropertiesMutation : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IAssignRandomDataSourcePropertiesResult>> ExecuteAsync(global::System.String definitionId, global::industry9.Client.Data.GraphQL.Generated.RandomDataSourcePropertiesInput properties, global::System.Threading.CancellationToken cancellationToken = default);
        global::System.IObservable<global::StrawberryShake.IOperationResult<IAssignRandomDataSourcePropertiesResult>> Watch(global::System.String definitionId, global::industry9.Client.Data.GraphQL.Generated.RandomDataSourcePropertiesInput properties, global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}
