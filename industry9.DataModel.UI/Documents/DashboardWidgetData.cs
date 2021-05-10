using System.Drawing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace industry9.DataModel.UI.Documents
{
    public class DashboardWidgetData
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string WidgetId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DashboardId { get; set; }

        [BsonIgnore]
        public WidgetDocument Widget { get; set; }

        public Size Size { get; set; }
        public Point Position { get; set; }
    }
}
