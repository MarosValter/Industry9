using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ColumnMappingDataInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _stringSerializer;

        public string Name { get; } = "ColumnMappingDataInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(ColumnMappingDataInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _needsInitialization = false;
        }

        public object Serialize(object value)
        {
            if (_needsInitialization)
            {
                throw new InvalidOperationException(
                    $"The serializer for type `{Name}` has not been initialized.");
            }

            if (value is null)
            {
                return null;
            }

            var input = (ColumnMappingDataInput)value;
            var map = new Dictionary<string, object>();

            if (input.DataSourceId.HasValue)
            {
                map.Add("dataSourceId", SerializeNullableString(input.DataSourceId.Value));
            }

            if (input.Format.HasValue)
            {
                map.Add("format", SerializeNullableString(input.Format.Value));
            }

            if (input.Name.HasValue)
            {
                map.Add("name", SerializeNullableString(input.Name.Value));
            }

            if (input.SourceColumn.HasValue)
            {
                map.Add("sourceColumn", SerializeNullableString(input.SourceColumn.Value));
            }

            return map;
        }

        private object SerializeNullableString(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _stringSerializer.Serialize(value);
        }

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
