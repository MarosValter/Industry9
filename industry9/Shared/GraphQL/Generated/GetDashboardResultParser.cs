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

        public GetDashboardResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
        }

        protected override IGetDashboard ParserData(JsonElement data)
        {
            return new GetDashboard
            (
                ParseGetDashboardDashboard(data, "dashboard")
            );

        }

        private global::industry9.Shared.IDashboard ParseGetDashboardDashboard(
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

            return new Dashboard
            (
                DeserializeNullableString(obj, "id"),
                DeserializeNullableString(obj, "name"),
                ParseGetDashboardDashboardLabels(obj, "labels"),
                ParseGetDashboardDashboardWidgets(obj, "widgets")
            );
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.ILabelData> ParseGetDashboardDashboardLabels(
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
            var list = new global::industry9.Shared.ILabelData[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new LabelData
                (
                    DeserializeNullableString(element, "name")
                );

            }

            return list;
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IWidget> ParseGetDashboardDashboardWidgets(
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
            var list = new global::industry9.Shared.IWidget[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Widget
                (
                    DeserializeNullableString(element, "id")
                );

            }

            return list;
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
    }
}
