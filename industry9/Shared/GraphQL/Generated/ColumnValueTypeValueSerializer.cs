using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ColumnValueTypeValueSerializer
        : IValueSerializer
    {
        public string Name => "ColumnValueType";

        public ValueKind Kind => ValueKind.Enum;

        public Type ClrType => typeof(ColumnValueType);

        public Type SerializationType => typeof(string);

        public object Serialize(object value)
        {
            if (value is null)
            {
                return null;
            }

            var enumValue = (ColumnValueType)value;

            switch(enumValue)
            {
                case ColumnValueType.Unknown:
                    return "UNKNOWN";
                case ColumnValueType.String:
                    return "STRING";
                case ColumnValueType.Number:
                    return "NUMBER";
                case ColumnValueType.Datetime:
                    return "DATETIME";
                case ColumnValueType.Boolean:
                    return "BOOLEAN";
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
                    return ColumnValueType.Unknown;
                case "STRING":
                    return ColumnValueType.String;
                case "NUMBER":
                    return ColumnValueType.Number;
                case "DATETIME":
                    return ColumnValueType.Datetime;
                case "BOOLEAN":
                    return ColumnValueType.Boolean;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
