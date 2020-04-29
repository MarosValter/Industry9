using System.Collections.Generic;
using industry9.Common.Structs;
using MongoDB.Bson;

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


        //public NavigationSettings Navigation { get; set; }
        //public TimeSettings TimeSettings { get; set; }

        //public ShareOptions ShareOptions { get; set; }

        public IReadOnlyList<LabelData> Labels { get; set; }

        public IReadOnlyList<ObjectId> WidgetIds { get; set; }
    }
}
