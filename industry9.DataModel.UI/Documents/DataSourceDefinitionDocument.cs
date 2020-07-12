using System.Collections.Generic;
using industry9.Common.Enums;

namespace industry9.DataModel.UI.Documents
{
    public class DataSourceDefinitionDocument : BaseDocument
    {
        public string Name { get; set; }
        public DataSourceType Type { get; set; }
        public IReadOnlyList<string> Inputs { get; set; }
        public IDataSourceProperties Properties { get; set; }
        public IReadOnlyList<ExportedColumnData> Columns { get; set; }
    }
}
