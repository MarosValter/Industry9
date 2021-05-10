using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.DataSourceDefinition;

namespace industry9.GraphQL.UI.DataLoaders
{
    public class DataSourceDefinitionDataLoader : BatchDataLoader<string, DataSourceDefinitionDocument>
    {
        private readonly IDataSourceDefinitionRepository _repository;

        public DataSourceDefinitionDataLoader(
            IDataSourceDefinitionRepository repository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions<string>? options = null)
            : base(batchScheduler, options)
        {
            _repository = repository;
        }

        protected override Task<IReadOnlyDictionary<string, DataSourceDefinitionDocument>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            return _repository.GetDocuments(keys, cancellationToken);
        }
    }
}
