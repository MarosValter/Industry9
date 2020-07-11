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
    public partial class FetchRandomDataSourcePropertiesResultParser
        : JsonResultParserBase<IFetchRandomDataSourceProperties>
    {
        private readonly IValueSerializer _intSerializer;

        public FetchRandomDataSourcePropertiesResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.Get("Int");
        }

        protected override IFetchRandomDataSourceProperties ParserData(JsonElement data)
        {
            return new FetchRandomDataSourceProperties
            (
                ParseFetchRandomDataSourcePropertiesFetchRandomPropertiesFromDataSource(data, "fetchRandomPropertiesFromDataSource")
            );

        }

        private global::industry9.Shared.IRandomDataSourceProperties ParseFetchRandomDataSourcePropertiesFetchRandomPropertiesFromDataSource(
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

            return new RandomDataSourceProperties
            (
                DeserializeInt(obj, "min"),
                DeserializeInt(obj, "max")
            );
        }

        private int DeserializeInt(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (int)_intSerializer.Deserialize(value.GetInt32());
        }
    }
}
