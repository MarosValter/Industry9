using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace industry9.DataModel.UI.Documents
{
    public class ColumnMappingData
    {
        public string Name { get; set; }
        public string Format { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DataSourceId { get; set; }
        public string SourceColumn { get; set; }
    }
}
