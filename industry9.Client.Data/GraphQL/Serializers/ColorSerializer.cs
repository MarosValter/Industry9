//using System;
//using System.Drawing;
//using StrawberryShake;
//using StrawberryShake.Serializers;

//namespace industry9.Shared.GraphQL.Serializers
//{
//    public class ColorSerializer : ValueSerializerBase<Color, string>
//    {
//        public override string Name => "Color";
//        public override ValueKind Kind => ValueKind.String;

//        public override object Serialize(object value)
//        {
//            if (value is null)
//            {
//                return null;
//            }

//            if (value is Color c)
//            {
//                return c.ToString();
//            }

//            throw new ArgumentException($"The specified value is of an invalid type. {ClrType.FullName} was expected.");
//        }

//        public override object Deserialize(object serialized)
//        {
//            if (serialized is null)
//            {
//                return null;
//            }

//            if (serialized is string s)
//            {
//                return Color.FromName(s);
//            }

//            throw new ArgumentException($"The specified value is of an invalid type. {SerializationType.FullName} was expected.");
//        }
//    }
//}
