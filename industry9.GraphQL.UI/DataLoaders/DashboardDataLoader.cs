using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Dashboard;

namespace industry9.GraphQL.UI.DataLoaders
{
    public class DashboardDataLoader : BatchDataLoader<string, DashboardDocument>
    {
        private readonly IDashboardRepository _repository;

        public DashboardDataLoader(
            IDashboardRepository repository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions<string>? options = null)
            : base(batchScheduler, options)
        {
            _repository = repository;
        }

        protected override Task<IReadOnlyDictionary<string, DashboardDocument>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            return _repository.GetDocuments(keys, cancellationToken);
        }
    }
}
