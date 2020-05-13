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
