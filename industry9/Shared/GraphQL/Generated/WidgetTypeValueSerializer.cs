using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class WidgetTypeValueSerializer
        : IValueSerializer
    {
        public string Name => "WidgetType";

        public ValueKind Kind => ValueKind.Enum;

        public Type ClrType => typeof(WidgetType);

        public Type SerializationType => typeof(string);

        public object Serialize(object value)
        {
            if (value is null)
            {
                return null;
            }

            var enumValue = (WidgetType)value;

            switch(enumValue)
            {
                case WidgetType.Linechart:
                    return "LINECHART";
                case WidgetType.Barchart:
                    return "BARCHART";
                case WidgetType.Piechart:
                    return "PIECHART";
                case WidgetType.Table:
                    return "TABLE";
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
                case "LINECHART":
                    return WidgetType.Linechart;
                case "BARCHART":
                    return WidgetType.Barchart;
                case "PIECHART":
                    return WidgetType.Piechart;
                case "TABLE":
                    return WidgetType.Table;
                default:
                    throw new NotSupportedException();
            }
        }

    }
}
