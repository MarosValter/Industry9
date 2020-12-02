using System;
using System.Drawing;
using StrawberryShake;
using StrawberryShake.Serializers;

namespace industry9.Shared.GraphQL.Serializers
{
    public class SizeValueSerializer : ValueSerializerBase<Size, string>
    {
        public override string Name => "Size";
        public override ValueKind Kind => ValueKind.String;

        public override object Serialize(object value)
        {
            if (value is null)
            {
                return null;
            }

            if (value is Size s)
            {
                return $"{s.Width},{s.Height}";
            }

            throw new ArgumentException($"The specified value is of an invalid type. {ClrType.FullName} was expected.");
        }

        public override object Deserialize(object serialized)
        {
            if (serialized is null)
            {
                return null;
            }

            if (serialized is string s)
            {
                var parts = s.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    return null;
                }

                return new Size(int.Parse(parts[0]), int.Parse(parts[1]));
            }

            throw new ArgumentException($"The specified value is of an invalid type. {SerializationType.FullName} was expected.");
        }
    }
}
