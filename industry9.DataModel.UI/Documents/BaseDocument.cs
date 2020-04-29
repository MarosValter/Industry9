using System;
using MongoDB.Bson;

namespace industry9.DataModel.UI.Documents
{
    public class BaseDocument : IDocument
    {
        public BaseDocument()
        {
            Created = DateTimeOffset.Now;
        }

        public ObjectId Id { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
