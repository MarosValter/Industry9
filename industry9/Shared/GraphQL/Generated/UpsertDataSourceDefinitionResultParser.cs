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
    public partial class UpsertDataSourceDefinitionResultParser
        : JsonResultParserBase<IUpsertDataSourceDefinition>
    {
        private readonly IValueSerializer _stringSerializer;

        public UpsertDataSourceDefinitionResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
        }

        protected override IUpsertDataSourceDefinition ParserData(JsonElement data)
        {
            return new UpsertDataSourceDefinition
            (
                ParseUpsertDataSourceDefinitionCreateDataSourceDefinition(data, "createDataSourceDefinition")
            );

        }

        private global::industry9.Shared.IDataSourceDefinitionId ParseUpsertDataSourceDefinitionCreateDataSourceDefinition(
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

            return new DataSourceDefinitionId
            (
                DeserializeString(obj, "id")
            );
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
        }
    }
}
