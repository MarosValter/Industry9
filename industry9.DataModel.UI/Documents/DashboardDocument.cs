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
            Widgets = new List<DashboardWidgetData>();
        }

        public string Name { get; set; }

        public bool Private { get; set; }

        public int ColumnCount { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AuthorId { get; set; }

        //public TimeSettings TimeSettings { get; set; }

        public IReadOnlyCollection<LabelData> Labels { get; set; }

        public IReadOnlyCollection<DashboardWidgetData> Widgets { get; set; }
    }
}
