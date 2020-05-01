using MongoDB.Bson;

namespace industry9.DataModel.UI.Documents
{
    public class WidgetInputDocument : WidgetDocument
    {
        public ObjectId? DashboardId { get; set; }
    }
}
