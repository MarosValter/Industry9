using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DashboardWidgetInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _stringSerializer;
        private IValueSerializer _positionInputSerializer;
        private IValueSerializer _sizeInputSerializer;

        public string Name { get; } = "DashboardWidgetInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(DashboardWidgetInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _positionInputSerializer = serializerResolver.Get("PositionInput");
            _sizeInputSerializer = serializerResolver.Get("SizeInput");
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

            var input = (DashboardWidgetInput)value;
            var map = new Dictionary<string, object>();

            if (input.DashboardId.HasValue)
            {
                map.Add("dashboardId", SerializeNullableString(input.DashboardId.Value));
            }

            if (input.Position.HasValue)
            {
                map.Add("position", SerializeNullablePositionInput(input.Position.Value));
            }

            if (input.Size.HasValue)
            {
                map.Add("size", SerializeNullableSizeInput(input.Size.Value));
            }

            if (input.WidgetId.HasValue)
            {
                map.Add("widgetId", SerializeNullableString(input.WidgetId.Value));
            }

            return map;
        }

        private object SerializeNullableString(object value)
        {
            return _stringSerializer.Serialize(value);
        }
        private object SerializeNullablePositionInput(object value)
        {
            return _positionInputSerializer.Serialize(value);
        }
        private object SerializeNullableSizeInput(object value)
        {
            return _sizeInputSerializer.Serialize(value);
        }

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
