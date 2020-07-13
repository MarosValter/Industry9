using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class WidgetInputSerializer
        : IInputSerializer
    {
        private bool _needsInitialization = true;
        private IValueSerializer _columnMappingDataInputSerializer;
        private IValueSerializer _stringSerializer;
        private IValueSerializer _labelDataInputSerializer;
        private IValueSerializer _widgetTypeSerializer;

        public string Name { get; } = "WidgetInput";

        public ValueKind Kind { get; } = ValueKind.InputObject;

        public Type ClrType => typeof(WidgetInput);

        public Type SerializationType => typeof(IReadOnlyDictionary<string, object>);

        public void Initialize(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _columnMappingDataInputSerializer = serializerResolver.Get("ColumnMappingDataInput");
            _stringSerializer = serializerResolver.Get("String");
            _labelDataInputSerializer = serializerResolver.Get("LabelDataInput");
            _widgetTypeSerializer = serializerResolver.Get("WidgetType");
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

            var input = (WidgetInput)value;
            var map = new Dictionary<string, object>();

            if (input.ColumnMappings.HasValue)
            {
                map.Add("columnMappings", SerializeNullableListOfNullableColumnMappingDataInput(input.ColumnMappings.Value));
            }

            if (input.DashboardId.HasValue)
            {
                map.Add("dashboardId", SerializeNullableString(input.DashboardId.Value));
            }

            if (input.DataSourceIds.HasValue)
            {
                map.Add("dataSourceIds", SerializeNullableListOfNullableString(input.DataSourceIds.Value));
            }

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

            if (input.Type.HasValue)
            {
                map.Add("type", SerializeNullableWidgetType(input.Type.Value));
            }

            return map;
        }

        private object SerializeNullableColumnMappingDataInput(object value)
        {
            if (value is null)
            {
                return null;
            }


            return _columnMappingDataInputSerializer.Serialize(value);
        }

        private object SerializeNullableListOfNullableColumnMappingDataInput(object value)
        {
            if (value is null)
            {
                return null;
            }


            IList source = (IList)value;
            object[] result = new object[source.Count];
            for(int i = 0; i < source.Count; i++)
            {
                result[i] = SerializeNullableColumnMappingDataInput(source[i]);
            }
            return result;
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
        private object SerializeNullableWidgetType(object value)
        {
            return _widgetTypeSerializer.Serialize(value);
        }

        public object Deserialize(object value)
        {
            throw new NotSupportedException(
                "Deserializing input values is not supported.");
        }
    }
}
