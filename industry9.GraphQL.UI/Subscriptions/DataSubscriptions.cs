using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using industry9.DataModel.UI.Data;
using industry9.DataModel.UI.Documents;

namespace industry9.GraphQL.UI.Subscriptions
{
    [ExtendObjectType("Subscription")]
    public class DataSubscriptions
    {
        [Subscribe(With = nameof(SubscribeToDataReceivedAsync))]
        public Task<SensorData> OnDataReceived(
            [ID(nameof(DataSourceDefinitionDocument))] string dataSourceId,
            [EventMessage] SensorData data)
        {
            return Task.FromResult(data);
        }

        public async ValueTask<ISourceStream<SensorData>> SubscribeToDataReceivedAsync(
            string dataSourceId,
            [Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken) =>
            await eventReceiver.SubscribeAsync<string, SensorData>(
                $"{nameof(OnDataReceived)}_{dataSourceId}", cancellationToken);
    }
}
