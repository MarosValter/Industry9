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
    public partial class GetDataSourceDefinitionsResultParser
        : JsonResultParserBase<IGetDataSourceDefinitions>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _dateTimeSerializer;
        private readonly IValueSerializer _dataSourceTypeSerializer;
        private readonly IValueSerializer _columnValueTypeSerializer;

        public GetDataSourceDefinitionsResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
            _dataSourceTypeSerializer = serializerResolver.Get("DataSourceType");
            _columnValueTypeSerializer = serializerResolver.Get("ColumnValueType");
        }

        protected override IGetDataSourceDefinitions ParserData(JsonElement data)
        {
            return new GetDataSourceDefinitions
            (
                ParseGetDataSourceDefinitionsDataSourceDefinitions(data, "dataSourceDefinitions")
            );

        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IDataSourceDefinitionLite> ParseGetDataSourceDefinitionsDataSourceDefinitions(
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
            var list = new global::industry9.Shared.IDataSourceDefinitionLite[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new DataSourceDefinitionLite
                (
                    DeserializeString(element, "id"),
                    DeserializeNullableString(element, "name"),
                    DeserializeDateTime(element, "created"),
                    DeserializeDataSourceType(element, "type"),
                    ParseGetDataSourceDefinitionsDataSourceDefinitionsColumns(element, "columns")
                );

            }

            return list;
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IExportedColumn> ParseGetDataSourceDefinitionsDataSourceDefinitionsColumns(
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
            var list = new global::industry9.Shared.IExportedColumn[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new ExportedColumn
                (
                    DeserializeNullableString(element, "name"),
                    DeserializeColumnValueType(element, "valueType")
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

        private DataSourceType DeserializeDataSourceType(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (DataSourceType)_dataSourceTypeSerializer.Deserialize(value.GetString());
        }
        private ColumnValueType DeserializeColumnValueType(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (ColumnValueType)_columnValueTypeSerializer.Deserialize(value.GetString());
        }
    }
}
