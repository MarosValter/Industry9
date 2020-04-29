using System;
using MongoDB.Bson;

namespace industry9.DataModel.UI.Documents
{
    public interface IDocument
    {
        ObjectId Id { get; set; }
        DateTimeOffset Created { get; set; }
    }
}
