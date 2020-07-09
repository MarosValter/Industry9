using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Widget;

namespace industry9.GraphQL.UI.Widget
{
    [ExtendObjectType(Name = "Mutation")]
    public class WidgetMutations
    {
        public async Task<string> UpsertWidget(WidgetInputDocument widget,
            [Service] IWidgetRepository widgetRepository, IResolverContext ctx)
        {
            await widgetRepository.UpsertDocumentAsync(widget, ctx.RequestAborted);
            return widget.Id;
        }

        public async Task<bool> DeleteWidget(string id,
            [Service] IWidgetRepository widgetRepository, IResolverContext ctx)
        {
            var result = await widgetRepository.DeleteDocumentAsync(id, ctx.RequestAborted);
            return result.IsAcknowledged;
        }
    }
}
