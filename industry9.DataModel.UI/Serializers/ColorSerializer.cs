using System;
using System.Drawing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace industry9.DataModel.UI.Serializers
{
    public class ColorSerializer : SerializerBase<Color>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Color value)
        {
            context.Writer.WriteString(value.ToString());
        }

        public override Color Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            if (context.Reader.GetCurrentBsonType() != BsonType.String)
            {
                throw new ArgumentException();
            }

            var color = Color.FromName(context.Reader.ReadString());
            return color;
        }
    }
}
