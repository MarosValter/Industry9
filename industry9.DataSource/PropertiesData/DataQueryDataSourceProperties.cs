using industry9.Common.Enums;
using industry9.Common.GraphQL;
using industry9.DataModel.UI.Documents;

namespace industry9.DataSource.PropertiesData
{
    [DataSourceProperties(DataSourceType.DataQuery)]
    public class DataQueryDataSourceProperties : IDataSourceProperties
    {
        public string DefinitionId { get; set; }
        public string Query { get; set; }
    }
}
