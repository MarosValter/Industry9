﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    /// <summary>
    /// Represents the operation service of the GetWidgets GraphQL operation
    /// <code>
    /// query GetWidgets {
    ///   widgets {
    ///     __typename
    ///     ... WidgetLite
    ///     ... on Widget {
    ///       id
    ///     }
    ///   }
    /// }
    /// 
    /// fragment WidgetLite on Widget {
    ///   id
    ///   name
    ///   created
    ///   type
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
    public interface IGetWidgetsQuery : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IGetWidgetsResult>> ExecuteAsync(global::System.Threading.CancellationToken cancellationToken = default);
        global::System.IObservable<global::StrawberryShake.IOperationResult<IGetWidgetsResult>> Watch(global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}
