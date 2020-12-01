using System;

namespace industry9.DataModel.UI.Data
{
    public class SensorData
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string DataSourceId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
