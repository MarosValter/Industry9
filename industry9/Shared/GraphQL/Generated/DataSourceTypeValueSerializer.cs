using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DataSourceTypeValueSerializer
        : IValueSerializer
    {
        public string Name => "DataSourceType";

        public ValueKind Kind => ValueKind.Enum;

        public Type ClrType => typeof(DataSourceType);

        public Type SerializationType => typeof(string);

        public object Serialize(object value)
        {
            if (value is null)
            {
                return null;
            }

            var enumValue = (DataSourceType)value;

            switch(enumValue)
            {
                case DataSourceType.Unknown:
                    return "UNKNOWN";
                case DataSourceType.Random:
                    return "RANDOM";
                case DataSourceType.Dataquery:
                    return "DATAQUERY";
                default:
                    throw new NotSupportedException();
            }
        }

        public object Deserialize(object serialized)
        {
            if (serialized is null)
            {
                return null;
            }

            var stringValue = (string)serialized;

            switch(stringValue)
            {
                case "UNKNOWN":
                    return DataSourceType.Unknown;
                case "RANDOM":
                    return DataSourceType.Random;
                case "DATAQUERY":
                    return DataSourceType.Dataquery;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
