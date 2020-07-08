using System.Threading;
using System.Threading.Tasks;
using industry9.DataModel.UI.Documents;
using MongoDB.Driver;

namespace industry9.DataModel.UI.Repositories.DataSourceDefinition
{
    public class DataSourceDefinitionRepository : BaseDocumentRepository<DataSourceDefinitionDocument>, IDataSourceDefinitionRepository
    {
        public DataSourceDefinitionRepository(IMongoCollection<DataSourceDefinitionDocument> collection) : base(collection)
        {
        }

        public async Task<UpdateResult> AssignProperties(string dataSourceId, IDataSourceProperties properties, CancellationToken cancellationToken = default)
        {
            var filter = Builders<DataSourceDefinitionDocument>.Filter.Eq(d => d.Id, dataSourceId);
            var update = Builders<DataSourceDefinitionDocument>.Update.Set(d => d.Properties, properties);
            return await Collection.UpdateOneAsync(filter, update, null, cancellationToken);
        }
    }
}
