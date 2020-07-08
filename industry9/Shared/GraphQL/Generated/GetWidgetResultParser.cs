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
    public partial class GetWidgetResultParser
        : JsonResultParserBase<IGetWidget>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _dateTimeSerializer;
        private readonly IValueSerializer _widgetTypeSerializer;

        public GetWidgetResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
            _widgetTypeSerializer = serializerResolver.Get("WidgetType");
        }

        protected override IGetWidget ParserData(JsonElement data)
        {
            return new GetWidget
            (
                ParseGetWidgetWidget(data, "widget")
            );

        }

        private global::industry9.Shared.IWidgetDetail ParseGetWidgetWidget(
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

            return new WidgetDetail
            (
                DeserializeString(obj, "id"),
                DeserializeNullableString(obj, "name"),
                DeserializeDateTime(obj, "created"),
                DeserializeWidgetType(obj, "type"),
                ParseGetWidgetWidgetLabels(obj, "labels"),
                ParseGetWidgetWidgetColumnMappings(obj, "columnMappings")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IColumnMapping> ParseGetWidgetWidgetColumnMappings(
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

            int objLength = obj.GetArrayLength();
            var list = new global::industry9.Shared.IColumnMapping[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new ColumnMapping
                (
                    DeserializeNullableString(element, "name"),
                    DeserializeNullableString(element, "format"),
                    DeserializeNullableString(element, "dataSourceId"),
                    DeserializeNullableString(element, "sourceColumn")
                );

            }

            return list;
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> ParseGetWidgetWidgetLabels(
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

            int objLength = obj.GetArrayLength();
            var list = new global::industry9.Shared.ILabel[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Label
                (
                    DeserializeNullableString(element, "name")
                );

            }

            return list;
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
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

        private System.DateTimeOffset DeserializeDateTime(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.DateTimeOffset)_dateTimeSerializer.Deserialize(value.GetString());
        }

        private WidgetType DeserializeWidgetType(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (WidgetType)_widgetTypeSerializer.Deserialize(value.GetString());
        }
    }
}
