using System.Threading;
using System.Threading.Tasks;
using industry9.DataModel.UI.Documents;
using MongoDB.Driver;

namespace industry9.DataModel.UI.Repositories.DataSourceDefinition
{
    public interface IDataSourceDefinitionRepository : IBaseDocumentRepository<DataSourceDefinitionDocument>
    {
        Task<UpdateResult> AssignProperties(string dataSourceId, IDataSourceProperties properties, CancellationToken cancellationToken = default);
    }
}