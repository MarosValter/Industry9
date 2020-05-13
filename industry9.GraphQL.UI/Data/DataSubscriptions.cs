using HotChocolate.Types;
using HotChocolate.Subscriptions;
using industry9.DataModel.UI.Data;

namespace industry9.GraphQL.UI.Data
{
    [ExtendObjectType(Name = "Subscription")]
    public class DataSubscriptions
    {
        //[Subscribe]
        //public async IAsyncEnumerable<SensorData> OnDataReceivedAsync(
        //    string widgetId, [Service] IEventRegistry registry, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        //{
        //    var @event = new EventDescription("DataReceived", new ArgumentNode("WidgetId", widgetId));
        //    var stream = await registry.SubscribeAsync(@event, cancellationToken).ConfigureAwait(false);
        //    await foreach (var item in stream.ConfigureAwait(false).WithCancellation(cancellationToken))
        //    {
        //        yield return (SensorData)item.Payload;
        //    }
        //}

        //[Subscribe]
        public SensorData OnDataReceived(string widgetId, IEventMessage message)
        {
            return (SensorData) message.Payload;
        }
    }
}
