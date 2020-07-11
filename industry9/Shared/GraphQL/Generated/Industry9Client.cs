using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Industry9Client
        : IIndustry9Client
    {
        private const string _clientName = "industry9Client";

        private readonly global::StrawberryShake.IOperationExecutor _executor;
        private readonly global::StrawberryShake.IOperationStreamExecutor _streamExecutor;

        public Industry9Client(global::StrawberryShake.IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
            _streamExecutor = executorPool.CreateStreamExecutor(_clientName);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetDashboards>> GetDashboardsAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetDashboardsOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetDashboards>> GetDashboardsAsync(
            GetDashboardsOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetDashboard>> GetDashboardAsync(
            global::StrawberryShake.Optional<string> id = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (id.HasValue && id.Value is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _executor.ExecuteAsync(
                new GetDashboardOperation { Id = id },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetDashboard>> GetDashboardAsync(
            GetDashboardOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetWidgets>> GetWidgetsAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetWidgetsOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetWidgets>> GetWidgetsAsync(
            GetWidgetsOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetWidget>> GetWidgetAsync(
            global::StrawberryShake.Optional<string> id = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (id.HasValue && id.Value is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _executor.ExecuteAsync(
                new GetWidgetOperation { Id = id },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetWidget>> GetWidgetAsync(
            GetWidgetOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetDataSourceDefinitions>> GetDataSourceDefinitionsAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetDataSourceDefinitionsOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetDataSourceDefinitions>> GetDataSourceDefinitionsAsync(
            GetDataSourceDefinitionsOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetDataSourceDefinition>> GetDataSourceDefinitionAsync(
            global::StrawberryShake.Optional<string> id = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (id.HasValue && id.Value is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _executor.ExecuteAsync(
                new GetDataSourceDefinitionOperation { Id = id },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IGetDataSourceDefinition>> GetDataSourceDefinitionAsync(
            GetDataSourceDefinitionOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IUpsertDashboard>> UpsertDashboardAsync(
            global::StrawberryShake.Optional<global::industry9.Shared.DashboardInput> dashboard = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (dashboard.HasValue && dashboard.Value is null)
            {
                throw new ArgumentNullException(nameof(dashboard));
            }

            return _executor.ExecuteAsync(
                new UpsertDashboardOperation { Dashboard = dashboard },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IUpsertDashboard>> UpsertDashboardAsync(
            UpsertDashboardOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IDeleteDashboard>> DeleteDashboardAsync(
            global::StrawberryShake.Optional<string> id = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (id.HasValue && id.Value is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _executor.ExecuteAsync(
                new DeleteDashboardOperation { Id = id },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IDeleteDashboard>> DeleteDashboardAsync(
            DeleteDashboardOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IUpsertWidget>> UpsertWidgetAsync(
            global::StrawberryShake.Optional<global::industry9.Shared.WidgetInput> widget = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (widget.HasValue && widget.Value is null)
            {
                throw new ArgumentNullException(nameof(widget));
            }

            return _executor.ExecuteAsync(
                new UpsertWidgetOperation { Widget = widget },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IUpsertWidget>> UpsertWidgetAsync(
            UpsertWidgetOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IDeleteWidget>> DeleteWidgetAsync(
            global::StrawberryShake.Optional<string> id = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (id.HasValue && id.Value is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _executor.ExecuteAsync(
                new DeleteWidgetOperation { Id = id },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IDeleteWidget>> DeleteWidgetAsync(
            DeleteWidgetOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IUpsertDataSourceDefinition>> UpsertDataSourceDefinitionAsync(
            global::StrawberryShake.Optional<global::industry9.Shared.DataSourceDefinitionInput> definition = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (definition.HasValue && definition.Value is null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            return _executor.ExecuteAsync(
                new UpsertDataSourceDefinitionOperation { Definition = definition },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IUpsertDataSourceDefinition>> UpsertDataSourceDefinitionAsync(
            UpsertDataSourceDefinitionOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IDeleteDataSourceDefinition>> DeleteDataSourceDefinitionAsync(
            global::StrawberryShake.Optional<string> id = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (id.HasValue && id.Value is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _executor.ExecuteAsync(
                new DeleteDataSourceDefinitionOperation { Id = id },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IDeleteDataSourceDefinition>> DeleteDataSourceDefinitionAsync(
            DeleteDataSourceDefinitionOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IAssignRandomDataSourceProperties>> AssignRandomDataSourcePropertiesAsync(
            global::StrawberryShake.Optional<string> definitionId = default,
            global::StrawberryShake.Optional<global::industry9.Shared.RandomDataSourcePropertiesInput> properties = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (definitionId.HasValue && definitionId.Value is null)
            {
                throw new ArgumentNullException(nameof(definitionId));
            }

            if (properties.HasValue && properties.Value is null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            return _executor.ExecuteAsync(
                new AssignRandomDataSourcePropertiesOperation
                {
                    DefinitionId = definitionId, 
                    Properties = properties
                },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IAssignRandomDataSourceProperties>> AssignRandomDataSourcePropertiesAsync(
            AssignRandomDataSourcePropertiesOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IAssignQueryDataSourceProperties>> AssignQueryDataSourcePropertiesAsync(
            global::StrawberryShake.Optional<string> definitionId = default,
            global::StrawberryShake.Optional<global::industry9.Shared.DataQueryDataSourcePropertiesInput> properties = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (definitionId.HasValue && definitionId.Value is null)
            {
                throw new ArgumentNullException(nameof(definitionId));
            }

            if (properties.HasValue && properties.Value is null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            return _executor.ExecuteAsync(
                new AssignQueryDataSourcePropertiesOperation
                {
                    DefinitionId = definitionId, 
                    Properties = properties
                },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::industry9.Shared.IAssignQueryDataSourceProperties>> AssignQueryDataSourcePropertiesAsync(
            AssignQueryDataSourcePropertiesOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::industry9.Shared.IOnDataReceived>> OnDataReceivedAsync(
            global::StrawberryShake.Optional<string> widgetId = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (widgetId.HasValue && widgetId.Value is null)
            {
                throw new ArgumentNullException(nameof(widgetId));
            }

            return _streamExecutor.ExecuteAsync(
                new OnDataReceivedOperation { WidgetId = widgetId },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IResponseStream<global::industry9.Shared.IOnDataReceived>> OnDataReceivedAsync(
            OnDataReceivedOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _streamExecutor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
