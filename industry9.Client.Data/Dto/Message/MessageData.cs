using System;
using System.Collections.Generic;

namespace industry9.Client.Data.Dto.Message
{
    public class MessageData
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string DataSourceId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Dictionary<string, object> Labels { get; set; }
    }
}
