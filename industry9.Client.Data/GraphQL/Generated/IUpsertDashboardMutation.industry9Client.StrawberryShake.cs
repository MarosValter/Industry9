﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    /// <summary>
    /// Represents the operation service of the UpsertDashboard GraphQL operation
    /// <code>
    /// mutation UpsertDashboard($dashboard: DashboardInput!) {
    ///   upsertDashboard(dashboard: $dashboard)
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public interface IUpsertDashboardMutation : global::StrawberryShake.IOperationRequestFactory
    {
        global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IUpsertDashboardResult>> ExecuteAsync(global::industry9.Client.Data.GraphQL.Generated.DashboardInput dashboard, global::System.Threading.CancellationToken cancellationToken = default);
        global::System.IObservable<global::StrawberryShake.IOperationResult<IUpsertDashboardResult>> Watch(global::industry9.Client.Data.GraphQL.Generated.DashboardInput dashboard, global::StrawberryShake.ExecutionStrategy? strategy = null);
    }
}
