using HotChocolate;
using industry9.Common.Enums;
using industry9.Common.GraphQL;
using industry9.DataModel.UI.Documents;

namespace industry9.DataSource.PropertiesData
{
    [DataSourceProperties(DataSourceType.Random)]
    public class RandomDataSourceProperties : IDataSourceProperties
    {
        public string DefinitionId { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
