using System;
using industry9.Common.Structs;
using StrawberryShake;
using StrawberryShake.Serializers;

namespace industry9.Shared.GraphQL.Serializers
{
    public class PositionValueSerializer : ValueSerializerBase<Position, string>
    {
        public override string Name => "Position";
        public override ValueKind Kind => ValueKind.String;

        public override object Serialize(object value)
        {
            if (value is null)
            {
                return null;
            }

            if (value is Position c)
            {
                return c.ToString();
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
                return Position.FromString(s);
            }

            throw new ArgumentException($"The specified value is of an invalid type. {SerializationType.FullName} was expected.");
        }
    }
}
