using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DataSourceDefinitionInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _stringSerializer;
        private IValueSerializer _dataSourceTypeSerializer;

        public string Name { get; } = "DataSourceDefinitionInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(DataSourceDefinitionInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _dataSourceTypeSerializer = serializerResolver.Get("DataSourceType");
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

            var input = (DataSourceDefinitionInput)value;
            var map = new Dictionary<string, object>();

            if (input.Inputs.HasValue)
            {
                map.Add("inputs", SerializeNullableListOfNullableString(input.Inputs.Value));
            }

            if (input.Name.HasValue)
            {
                map.Add("name", SerializeNullableString(input.Name.Value));
            }

            if (input.Type.HasValue)
            {
                map.Add("type", SerializeNullableDataSourceType(input.Type.Value));
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

        private object SerializeNullableListOfNullableString(object value)
        {
            if (value is null)
            {
                return null;
            }


            IList source = (IList)value;
            object[] result = new object[source.Count];
            for(int i = 0; i < source.Count; i++)
            {
                result[i] = SerializeNullableString(source[i]);
            }
            return result;
        }
        private object SerializeNullableDataSourceType(object value)
        {
            return _dataSourceTypeSerializer.Serialize(value);
        }

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
