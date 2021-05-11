﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    /// <summary>
    /// Represents the operation service of the OnDataReceived GraphQL operation
    /// <code>
    /// subscription OnDataReceived($dataSourceId: ID!) {
    ///   onDataReceived(dataSourceId: $dataSourceId) {
    ///     __typename
    ///     name
    ///     value
    ///     dataSourceId
    ///     timestamp
    ///   }
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public interface IOnDataReceivedSubscription : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.IObservable<global::StrawberryShake.IOperationResult<IOnDataReceivedResult>> Watch(global::System.String dataSourceId, global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}
