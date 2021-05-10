using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.Widget;

namespace industry9.GraphQL.UI.Mutations
{
    [ExtendObjectType("Mutation")]
    public class WidgetMutations
    {
        public async Task<string> UpsertWidget(
            WidgetDocument widget,
            [Service] IWidgetRepository widgetRepository,
            IResolverContext ctx)
        {
            await widgetRepository.UpsertDocumentAsync(widget, ctx.RequestAborted);
            return widget.Id;
        }

        public async Task<bool> DeleteWidget(
            [ID(nameof(WidgetDocument))] string id,
            [Service] IWidgetRepository widgetRepository,
            IResolverContext ctx)
        {
            var result = await widgetRepository.DeleteDocumentAsync(id, ctx.RequestAborted);
            return result.IsAcknowledged;
        }
    }
}
