using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IIndustry9Client
    {
        Task<IOperationResult<global::industry9.Shared.IGetDashboards>> GetDashboardsAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetDashboards>> GetDashboardsAsync(
            GetDashboardsOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetDashboard>> GetDashboardAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetDashboard>> GetDashboardAsync(
            GetDashboardOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetWidgets>> GetWidgetsAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetWidgets>> GetWidgetsAsync(
            GetWidgetsOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetWidget>> GetWidgetAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetWidget>> GetWidgetAsync(
            GetWidgetOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetDataSourceDefinitions>> GetDataSourceDefinitionsAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetDataSourceDefinitions>> GetDataSourceDefinitionsAsync(
            GetDataSourceDefinitionsOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetDataSourceDefinition>> GetDataSourceDefinitionAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetDataSourceDefinition>> GetDataSourceDefinitionAsync(
            GetDataSourceDefinitionOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IUpsertDashboard>> UpsertDashboardAsync(
            Optional<global::industry9.Shared.DashboardInput> dashboard = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IUpsertDashboard>> UpsertDashboardAsync(
            UpsertDashboardOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IDeleteDashboard>> DeleteDashboardAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IDeleteDashboard>> DeleteDashboardAsync(
            DeleteDashboardOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IUpsertWidget>> UpsertWidgetAsync(
            Optional<global::industry9.Shared.WidgetInput> widget = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IUpsertWidget>> UpsertWidgetAsync(
            UpsertWidgetOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IDeleteWidget>> DeleteWidgetAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IDeleteWidget>> DeleteWidgetAsync(
            DeleteWidgetOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IUpsertDataSourceDefinition>> UpsertDataSourceDefinitionAsync(
            Optional<global::industry9.Shared.DataSourceDefinitionInput> definition = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IUpsertDataSourceDefinition>> UpsertDataSourceDefinitionAsync(
            UpsertDataSourceDefinitionOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IDeleteDataSourceDefinition>> DeleteDataSourceDefinitionAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IDeleteDataSourceDefinition>> DeleteDataSourceDefinitionAsync(
            DeleteDataSourceDefinitionOperation operation,
            CancellationToken cancellationToken = default);

        global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::industry9.Shared.IOnDataReceived>> OnDataReceivedAsync(
            Optional<string> widgetId = default,
            CancellationToken cancellationToken = default);

        global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::industry9.Shared.IOnDataReceived>> OnDataReceivedAsync(
            OnDataReceivedOperation operation,
            CancellationToken cancellationToken = default);
    }
}
