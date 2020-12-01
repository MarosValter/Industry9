using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SensorData
        : ISensorData
    {
        public SensorData(
            string name, 
            double value, 
            string dataSourceId, 
            System.DateTimeOffset timestamp)
        {
            Name = name;
            Value = value;
            DataSourceId = dataSourceId;
            Timestamp = timestamp;
        }

        public string Name { get; }

        public double Value { get; }

        public string DataSourceId { get; }

        public System.DateTimeOffset Timestamp { get; }
    }
}
