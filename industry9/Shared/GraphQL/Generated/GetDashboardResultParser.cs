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
    public partial class GetDashboardResultParser
        : JsonResultParserBase<IGetDashboard>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _dateTimeSerializer;
        private readonly IValueSerializer _intSerializer;
        private readonly IValueSerializer _widgetTypeSerializer;

        public GetDashboardResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
            _intSerializer = serializerResolver.Get("Int");
            _widgetTypeSerializer = serializerResolver.Get("WidgetType");
        }

        protected override IGetDashboard ParserData(JsonElement data)
        {
            return new GetDashboard
            (
                ParseGetDashboardDashboard(data, "dashboard")
            );

        }

        private global::industry9.Shared.IDashboardDetail ParseGetDashboardDashboard(
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

            return new DashboardDetail
            (
                DeserializeString(obj, "id"),
                DeserializeNullableString(obj, "name"),
                DeserializeNullableString(obj, "authorId"),
                DeserializeDateTime(obj, "created"),
                ParseGetDashboardDashboardLabels(obj, "labels"),
                ParseGetDashboardDashboardWidgets(obj, "widgets")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> ParseGetDashboardDashboardLabels(
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

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IDashboardWidget> ParseGetDashboardDashboardWidgets(
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
            var list = new global::industry9.Shared.IDashboardWidget[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new DashboardWidget
                (
                    DeserializeNullableString(element, "widgetId"),
                    ParseGetDashboardDashboardWidgetsWidget(element, "widget"),
                    ParseGetDashboardDashboardWidgetsSize(element, "size"),
                    ParseGetDashboardDashboardWidgetsPosition(element, "position")
                );

            }

            return list;
        }

        private global::industry9.Shared.IPosition ParseGetDashboardDashboardWidgetsPosition(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Position
            (
                DeserializeInt(obj, "x"),
                DeserializeInt(obj, "y")
            );
        }

        private global::industry9.Shared.ISize ParseGetDashboardDashboardWidgetsSize(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Size
            (
                DeserializeInt(obj, "width"),
                DeserializeInt(obj, "height")
            );
        }

        private global::industry9.Shared.IWidgetDetail ParseGetDashboardDashboardWidgetsWidget(
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
                ParseGetDashboardDashboardWidgetsWidgetLabels(obj, "labels"),
                ParseGetDashboardDashboardWidgetsWidgetColumnMappings(obj, "columnMappings")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IColumnMapping> ParseGetDashboardDashboardWidgetsWidgetColumnMappings(
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

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabel> ParseGetDashboardDashboardWidgetsWidgetLabels(
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
        private int DeserializeInt(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (int)_intSerializer.Deserialize(value.GetInt32());
        }
        private WidgetType DeserializeWidgetType(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (WidgetType)_widgetTypeSerializer.Deserialize(value.GetString());
        }
    }
}
