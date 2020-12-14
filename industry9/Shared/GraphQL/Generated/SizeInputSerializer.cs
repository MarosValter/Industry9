using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SizeInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _intSerializer;

        public string Name { get; } = "SizeInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(SizeInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _intSerializer = serializerResolver.Get("Int");
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

            var input = (SizeInput)value;
            var map = new Dictionary<string, object>();

            if (input.Height.HasValue)
            {
                map.Add("height", SerializeNullableInt(input.Height.Value));
            }

            if (input.Width.HasValue)
            {
                map.Add("width", SerializeNullableInt(input.Width.Value));
            }

            return map;
        }

        private object SerializeNullableInt(object value)
        {
            return _intSerializer.Serialize(value);
        }

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
