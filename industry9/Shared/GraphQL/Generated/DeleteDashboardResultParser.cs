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
    public partial class DeleteDashboardResultParser
        : JsonResultParserBase<IDeleteDashboard>
    {
        private readonly IValueSerializer _booleanSerializer;

        public DeleteDashboardResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _booleanSerializer = serializerResolver.Get("Boolean");
        }

        protected override IDeleteDashboard ParserData(JsonElement data)
        {
            return new DeleteDashboard1
            (
                DeserializeBoolean(data, "deleteDashboard")
            );

        }

        private bool DeserializeBoolean(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (bool)_booleanSerializer.Deserialize(value.GetBoolean());
        }
    }
}
