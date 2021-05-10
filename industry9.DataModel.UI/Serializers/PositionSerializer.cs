using System;
using System.Drawing;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace industry9.DataModel.UI.Serializers
{
    public class PositionSerializer : SerializerBase<Point>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Point value)
        {
            context.Writer.WriteStartDocument();
            context.Writer.WriteName(nameof(Point.X));
            context.Writer.WriteInt32(value.X);
            context.Writer.WriteName(nameof(Point.Y));
            context.Writer.WriteInt32(value.Y);
            context.Writer.WriteEndDocument();
        }

        public override Point Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartDocument();
            var heightName = context.Reader.ReadName(new Utf8NameDecoder());
            var x = context.Reader.ReadInt32();
            var widthName = context.Reader.ReadName(new Utf8NameDecoder());
            var y = context.Reader.ReadInt32();
            context.Reader.ReadEndDocument();

            return new Point
            {
                X = Convert.ToInt32(x),
                Y = Convert.ToInt32(y)
            };
        }
    }
}
