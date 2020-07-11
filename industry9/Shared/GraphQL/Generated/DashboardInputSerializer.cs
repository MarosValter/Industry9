using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DashboardInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _stringSerializer;
        private IValueSerializer _labelDataInputSerializer;

        public string Name { get; } = "DashboardInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(DashboardInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _stringSerializer = serializerResolver.Get("String");
            _labelDataInputSerializer = serializerResolver.Get("LabelDataInput");
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

            var input = (DashboardInput)value;
            var map = new Dictionary<string, object>();

            if (input.Id.HasValue)
            {
                map.Add("id", SerializeNullableString(input.Id.Value));
            }

            if (input.Labels.HasValue)
            {
                map.Add("labels", SerializeNullableListOfNullableLabelDataInput(input.Labels.Value));
            }

            if (input.Name.HasValue)
            {
                map.Add("name", SerializeNullableString(input.Name.Value));
            }

            if (input.WidgetIds.HasValue)
            {
                map.Add("widgetIds", SerializeNullableListOfNullableString(input.WidgetIds.Value));
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
        private object SerializeNullableLabelDataInput(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _labelDataInputSerializer.Serialize(value);
        }

        private object SerializeNullableListOfNullableLabelDataInput(object value)
        {
            if (value is null)
            {
                return null;
            }


            IList source = (IList)value;
            object[] result = new object[source.Count];
            for(int i = 0; i < source.Count; i++)
            {
                result[i] = SerializeNullableLabelDataInput(source[i]);
            }
            return result;
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

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
