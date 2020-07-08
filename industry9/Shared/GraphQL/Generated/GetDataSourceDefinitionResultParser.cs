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
    public partial class GetDataSourceDefinitionResultParser
        : JsonResultParserBase<IGetDataSourceDefinition>
    {
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _dateTimeSerializer;
        private readonly IValueSerializer _dataSourceTypeSerializer;

        public GetDataSourceDefinitionResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
            _dataSourceTypeSerializer = serializerResolver.Get("DataSourceType");
        }

        protected override IGetDataSourceDefinition ParserData(JsonElement data)
        {
            return new GetDataSourceDefinition
            (
                ParseGetDataSourceDefinitionDataSourceDefinition(data, "dataSourceDefinition")
            );

        }

        private global::industry9.Shared.IDataSourceDefinitionDetail ParseGetDataSourceDefinitionDataSourceDefinition(
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

            return new DataSourceDefinitionDetail
            (
                DeserializeString(obj, "id"),
                DeserializeDateTime(obj, "created"),
                DeserializeDataSourceType(obj, "type"),
                DeserializeNullableListOfNullableString(obj, "inputs")
            );
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
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

        private IReadOnlyList<string> DeserializeNullableListOfNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement list))
            {
                return null;
            }

            if (list.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            int listLength = list.GetArrayLength();
            var listList = new string[listLength];

            for (int i = 0; i < listLength; i++)
            {
                JsonElement element = list[i];
                if (element.ValueKind == JsonValueKind.Null)
                {
                    listList[i] = null;
                }
                else
                {
                    listList[i] = (string)_stringSerializer.Deserialize(element.GetString());
                }
            }
            return listList;
        }
    }
}
