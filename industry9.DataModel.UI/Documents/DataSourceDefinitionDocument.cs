using System.Collections.Generic;
using industry9.DataModel.UI.Enums;
using MongoDB.Bson;

namespace industry9.DataModel.UI.Documents
{
    public class DataSourceDefinitionDocument : BaseDocument
    {
        public DataSourceType Type { get; set; }
        public IReadOnlyList<ObjectId> Inputs { get; set; }
        public IDataSourceProperties Properties { get; set; }
    }
}
