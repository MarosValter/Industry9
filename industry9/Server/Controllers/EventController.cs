using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Language;
using HotChocolate.Subscriptions;
using industry9.DataModel.UI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace industry9.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IEventSender _eventSender;

        public EventController(ILogger<EventController> logger, IEventSender eventSender)
        {
            _logger = logger;
            _eventSender = eventSender;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task PublishData(SensorData data, CancellationToken cancellationToken = default)
        {
            await Publish(new EventData
            {
                Name = "onDataReceived",
                Value = data,
                Arguments = new[]
                {
                    new EventData.EventArgument
                    {
                        Name = "dataSourceId",
                        Value = data.DataSourceId
                    }
                }
            }, cancellationToken);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task Publish(EventData data, CancellationToken cancellationToken = default)
        {
            var arguments = data.Arguments.Select(kv => new ArgumentNode(kv.Name, kv.Value));
            var @event = new EventDescription(data.Name, arguments);
            var message = new EventMessage(@event, data.Value);
            await _eventSender.SendAsync(message, cancellationToken);
        }

        public class EventData
        {
            public string Name { get; set; }
            public SensorData Value { get; set; }
            public EventArgument[] Arguments { get; set; }

            public class EventArgument
            {
                public string Name { get; set; }
                public string Value { get; set; }
            }
        }
    }
}
