using industry9.DataModel.UI.Documents;
using MongoDB.Driver;

namespace industry9.DataModel.UI.Repositories.DataSourceDefinition
{
    public class DataSourceDefinitionRepository : BaseDocumentRepository<DataSourceDefinitionDocument>, IDataSourceDefinitionRepository
    {
        public DataSourceDefinitionRepository(IMongoCollection<DataSourceDefinitionDocument> collection) : base(collection)
        {
        }
    }
}
