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
    public partial class FetchQueryDataSourcePropertiesResultParser
        : JsonResultParserBase<IFetchQueryDataSourceProperties>
    {
        private readonly IValueSerializer _stringSerializer;

        public FetchQueryDataSourcePropertiesResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
        }

        protected override IFetchQueryDataSourceProperties ParserData(JsonElement data)
        {
            return new FetchQueryDataSourceProperties
            (
                ParseFetchQueryDataSourcePropertiesFetchDataQueryPropertiesFromDataSource(data, "fetchDataQueryPropertiesFromDataSource")
            );

        }

        private global::industry9.Shared.IDataQueryDataSourceProperties ParseFetchQueryDataSourcePropertiesFetchDataQueryPropertiesFromDataSource(
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

            return new DataQueryDataSourceProperties
            (
                DeserializeNullableString(obj, "query")
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
    }
}
