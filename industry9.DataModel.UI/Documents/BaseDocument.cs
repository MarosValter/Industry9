using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace industry9.DataModel.UI.Documents
{
    public class BaseDocument : IDocument
    {
        public BaseDocument()
        {
            Created = DateTimeOffset.Now;
        }

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
