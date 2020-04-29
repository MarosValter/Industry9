using MongoDB.Bson;

namespace industry9.DataModel.UI.Documents
{
    public class ColumnMappingData
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public ObjectId DataSourceId { get; set; }
        public string SourceColumn { get; set; }
    }
}
