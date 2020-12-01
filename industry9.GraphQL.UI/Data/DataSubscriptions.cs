using HotChocolate.Types;
using HotChocolate.Subscriptions;
using industry9.DataModel.UI.Data;

namespace industry9.GraphQL.UI.Data
{
    [ExtendObjectType(Name = "Subscription")]
    public class DataSubscriptions
    {
        public SensorData OnDataReceived(string dataSourceId, IEventMessage message)
        {
            return (SensorData) message.Payload;
        }
    }
}
