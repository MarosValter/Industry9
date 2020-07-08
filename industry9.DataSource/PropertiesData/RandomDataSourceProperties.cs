using HotChocolate;
using industry9.Common.Enums;
using industry9.Common.GraphQL;
using industry9.DataModel.UI.Documents;
using MongoDB.Bson.Serialization.Attributes;

namespace industry9.DataSource.PropertiesData
{
    //[BsonDiscriminator]
    [DataSourceProperties(DataSourceType.Random)]
    public class RandomDataSourceProperties : IDataSourceProperties
    {
        //[GraphQLIgnore]
        //public string Name { get; set; }

        public int Min { get; set; }
        public int Max { get; set; }
    }
}
