using System.Collections.Generic;
using industry9.Common.Enums;
using industry9.Common.Structs;
using MongoDB.Bson.Serialization.Attributes;

namespace industry9.DataModel.UI.Documents
{
    public class WidgetDocument : BaseDocument
    {
        public WidgetDocument()
        {
            Labels = new List<LabelData>();
            ColumnMappings = new List<ColumnMappingData>();
            DataSources = new List<DataSourceDefinitionDocument>();
        }

        public string Name { get; set; }

        public WidgetType Type { get; set; }

        //public Position Position { get; set; }
        //public Size Size { get; set; }
        //public TimeSettings TimeSettings { get; set; }

        public IReadOnlyList<LabelData> Labels { get; set; }

        public IReadOnlyList<ColumnMappingData> ColumnMappings { get; set; }

        [BsonIgnore]
        public IReadOnlyList<DataSourceDefinitionDocument> DataSources { get; set; }
    }
}
