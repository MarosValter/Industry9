using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnDataReceivedResultParser
        : JsonResultParserBase<IOnDataReceived>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _floatSerializer;
        private readonly IValueSerializer _dateTimeSerializer;

        public OnDataReceivedResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _floatSerializer = serializerResolver.Get("Float");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
        }

        protected override IOnDataReceived ParserData(JsonElement data)
        {
            return new OnDataReceived1
            (
                ParseOnDataReceivedOnDataReceived(data, "onDataReceived")
            );

        }

        private global::industry9.Shared.ISensorData ParseOnDataReceivedOnDataReceived(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new SensorData
            (
                DeserializeNullableString(obj, "name"),
                DeserializeFloat(obj, "value"),
                DeserializeNullableString(obj, "dataSourceId"),
                DeserializeDateTime(obj, "timestamp")
            );
        }

        private string DeserializeNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string)_stringSerializer.Deserialize(value.GetString());
        }

        private double DeserializeFloat(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (double)_floatSerializer.Deserialize(value.GetDouble());
        }

        private System.DateTimeOffset DeserializeDateTime(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.DateTimeOffset)_dateTimeSerializer.Deserialize(value.GetString());
        }
    }
}
