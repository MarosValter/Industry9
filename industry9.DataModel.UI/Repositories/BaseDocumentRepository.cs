using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using industry9.DataModel.UI.Documents;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace industry9.DataModel.UI.Repositories
{
    public abstract class BaseDocumentRepository<TDocument> : IBaseDocumentRepository<TDocument> where TDocument : IDocument
    {
        protected BaseDocumentRepository(IMongoCollection<TDocument> collection)
        {
            Collection = collection;
        }

        protected IMongoCollection<TDocument> Collection { get; }

        public IQueryable<TDocument> GetAllDocuments()
        {
            return Collection.AsQueryable();
        }

        public async Task<IReadOnlyDictionary<string, TDocument>> GetDocuments(IReadOnlyList<string> ids, CancellationToken cancellationToken = default)
        {
            var filters = ids.Select(id => Builders<TDocument>.Filter.Eq(u => u.Id, id)).ToList();
            var documents = await Collection.Find(Builders<TDocument>.Filter.Or(filters))
                .ToListAsync(cancellationToken);

            return documents.ToDictionary(d => d.Id);
        }

        public Task<TDocument> GetDocumentAsync(string id, CancellationToken cancellationToken = default)
        {
            return Collection.AsQueryable().FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        }

        public Task CreateDocumentAsync(TDocument document, CancellationToken cancellationToken = default)
        {
            return Collection.InsertOneAsync(document, null, cancellationToken);
        }

        public Task<UpdateResult> UpdateDocumentAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, CancellationToken cancellationToken = default)
        {
            return Collection.UpdateOneAsync(filter, update, null, cancellationToken);
        }

        public Task<DeleteResult> DeleteDocumentAsync(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default)
        {
            return Collection.DeleteOneAsync(filter, cancellationToken);
        }
    }
}
