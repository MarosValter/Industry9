using industry9.DataModel.UI.Documents;
using MongoDB.Driver;

namespace industry9.DataModel.UI.Repositories.Widget
{
    public class WidgetRepository : BaseDocumentRepository<WidgetDocument>, IWidgetRepository
    {
        public WidgetRepository(IMongoCollection<WidgetDocument> collection) : base(collection)
        {
        }
    }
}
