using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace industry9.DataModel.UI.Documents
{
    public class DashboardDocument : BaseDocument
    {
        public DashboardDocument()
        {
            Labels = new List<LabelData>();
            WidgetIds = new List<string>();
        }

        public string Name { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AuthorId { get; set; }

        //public TimeSettings TimeSettings { get; set; }

        public IReadOnlyCollection<LabelData> Labels { get; set; }

        [BsonIgnore]
        public IReadOnlyCollection<WidgetDocument> Widgets { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public IReadOnlyCollection<string> WidgetIds { get; set; }
    }
}
