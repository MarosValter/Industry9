using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using industry9.DataModel.UI.Documents;
using MongoDB.Bson;
using MongoDB.Driver;

namespace industry9.DataModel.UI.Repositories
{
    public interface IBaseDocumentRepository<TDocument> where TDocument : IDocument
    {
        IQueryable<TDocument> GetAllDocuments();
        Task<IReadOnlyDictionary<string, TDocument>> GetDocuments(IReadOnlyList<string> ids, CancellationToken cancellationToken = default);
        Task<TDocument> GetDocumentAsync(string id, CancellationToken cancellationToken = default);
        Task CreateDocumentAsync(TDocument document, CancellationToken cancellationToken = default);
        Task<UpdateResult> UpdateDocumentAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, CancellationToken cancellationToken = default);
        Task<DeleteResult> DeleteDocumentAsync(FilterDefinition<TDocument> filter, CancellationToken cancellationToken = default);
    }
}