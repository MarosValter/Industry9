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
            WidgetIds = new List<ObjectId>();
        }

        public string Name { get; set; }

        public ObjectId AuthorId { get; set; }

        //public TimeSettings TimeSettings { get; set; }

        public IReadOnlyCollection<LabelData> Labels { get; set; }

        [BsonIgnore]
        public IReadOnlyCollection<WidgetDocument> Widgets { get; set; }
        public IReadOnlyCollection<ObjectId> WidgetIds { get; set; }
    }
}
