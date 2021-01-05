using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Dto.Widget;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.Widget.Actions;

namespace industry9.Shared.Store.Features.Widget.Effects
{
    public class InitWidgetActionEffect : Effect<InitWidgetAction>
    {
        private readonly IIndustry9Client _client;

        public InitWidgetActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(InitWidgetAction action, IDispatcher dispatcher)
        {
            if (string.IsNullOrEmpty(action.Id))
            {
                dispatcher.Dispatch(new UpsertWidgetResultAction(new WidgetData()));
                return;
            }

            var result = await _client.GetWidgetAsync(action.Id);
            if (!result.HasErrors && result.Data != null)
            {
                var widget = MapWidget(result.Data.Widget);
                var resultAction = new UpsertWidgetResultAction(widget);
                dispatcher.Dispatch(resultAction);
            }
            else
            {
                result.DispatchToast(dispatcher, null, "Unable to fetch Widget");
            }
        }

        //TODO automapper
        public static WidgetData MapWidget(IWidgetDetail widget)
        {
            return new WidgetData
            {
                Id = widget.Id,
                Created = widget.Created.DateTime,
                Name = widget.Name,
                Type = widget.Type,
                Labels = widget.Labels.ToList(),
                ColumnMappings = widget.ColumnMappings.Select(MapColumn).ToList()
            };
        }

        //TODO automapper
        public static ColumnMappingData MapColumn(IColumnMapping column)
        {
            return new ColumnMappingData
            {
                Name = column.Name,
                Format = column.Format,
                DataSourceId = column.DataSourceId,
                SourceColumn = column.SourceColumn
            };
        }
    }
}
