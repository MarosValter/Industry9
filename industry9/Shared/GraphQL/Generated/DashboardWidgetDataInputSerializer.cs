using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DashboardWidgetDataInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _positionSerializer;
        private IValueSerializer _sizeSerializer;
        private IValueSerializer _widgetInputSerializer;
        private IValueSerializer _stringSerializer;

        public string Name { get; } = "DashboardWidgetDataInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(DashboardWidgetDataInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _positionSerializer = serializerResolver.Get("Position");
            _sizeSerializer = serializerResolver.Get("Size");
            _widgetInputSerializer = serializerResolver.Get("WidgetInput");
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

            var input = (DashboardWidgetDataInput)value;
            var map = new Dictionary<string, object>();

            if (input.Position.HasValue)
            {
                map.Add("position", SerializeNullablePosition(input.Position.Value));
            }

            if (input.Size.HasValue)
            {
                map.Add("size", SerializeNullableSize(input.Size.Value));
            }

            if (input.Widget.HasValue)
            {
                map.Add("widget", SerializeNullableWidgetInput(input.Widget.Value));
            }

            if (input.WidgetId.HasValue)
            {
                map.Add("widgetId", SerializeNullableString(input.WidgetId.Value));
            }

            return map;
        }

        private object SerializeNullablePosition(object value)
        {
            return _positionSerializer.Serialize(value);
        }
        private object SerializeNullableSize(object value)
        {
            return _sizeSerializer.Serialize(value);
        }
        private object SerializeNullableWidgetInput(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _widgetInputSerializer.Serialize(value);
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
