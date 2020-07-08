using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Widget;

namespace industry9.GraphQL.UI.Widget
{
    [ExtendObjectType(Name = "Query")]
    public class WidgetQueries
    {
        public IEnumerable<WidgetDocument> GetWidgets([Service] IWidgetRepository widgetRepository)
        {
            return widgetRepository.GetAllDocuments();
        }

        public async Task<WidgetDocument> GetWidget(string id,
            [Service] IWidgetRepository widgetRepository, IResolverContext ctx)
        {
            var widget = await widgetRepository.GetDocumentAsync(id, ctx.RequestAborted);
            if (widget == null)
            {
                ctx.ReportError($"Widget with Id {id} not found.");
            }

            return widget;
        }
    }
}
