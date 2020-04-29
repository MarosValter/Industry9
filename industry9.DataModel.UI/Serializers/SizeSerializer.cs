using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace industry9.DataModel.UI.Serializers
{
    public class SizeSerializer : SerializerBase<Size>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Size value)
        {
            context.Writer.WriteStartDocument();
            context.Writer.WriteName(nameof(Size.Height));
            context.Writer.WriteInt32(value.Height);
            context.Writer.WriteName(nameof(Size.Width));
            context.Writer.WriteInt32(value.Width);
            context.Writer.WriteEndDocument();
        }

        public override Size Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartDocument();
            var heightName = context.Reader.ReadName(new Utf8NameDecoder());
            var height = context.Reader.ReadInt32();
            var widthName = context.Reader.ReadName(new Utf8NameDecoder());
            var width = context.Reader.ReadInt32();
            context.Reader.ReadEndDocument();

            return new Size(width, height);
        }
    }
}
