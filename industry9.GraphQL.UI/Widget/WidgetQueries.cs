using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Widget;
using MongoDB.Bson;

namespace industry9.GraphQL.UI.Widget
{
    [ExtendObjectType(Name = "Query")]
    public class WidgetQueries
    {
        public async Task<WidgetDocument> GetWidget(string id, IResolverContext ctx,
            [Service] IWidgetRepository widgetRepository)
        {
            var widget = await widgetRepository.GetDocumentAsync(id);
            if (widget == null)
            {
                ctx.ReportError($"Widget with Id {id} not found.");
            }

            return widget;
        }
    }
}
