using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Widget;

namespace industry9.GraphQL.UI.DataLoaders
{
    public class WidgetDataLoader : BatchDataLoader<string, WidgetDocument>
    {
        private readonly IWidgetRepository _repository;

        public WidgetDataLoader(
            IWidgetRepository repository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions<string>? options = null)
            : base(batchScheduler, options)
        {
            _repository = repository;
        }

        protected override Task<IReadOnlyDictionary<string, WidgetDocument>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            return _repository.GetDocuments(keys, cancellationToken);
        }
    }
}
