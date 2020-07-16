using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Common.Enums;
using industry9.Shared.Dto.Widget;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.Widget.Actions;

namespace industry9.Shared.Store.Features.Widget.Effects
{
    public class UpsertWidgetActionEffect : Effect<UpsertWidgetResultAction>
    {
        private readonly IIndustry9Client _client;

        public UpsertWidgetActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(UpsertWidgetResultAction action, IDispatcher dispatcher)
        {
            if (!action.SaveChanges)
            {
                return;
            }

            var input = CreateInput(action.Widget);
            var result = await _client.UpsertWidgetAsync(input);

            if (!result.HasErrors)
            {
                dispatcher.Dispatch(new FetchWidgetsAction());
            }

            result.DispatchToast(dispatcher, "Widget", string.IsNullOrEmpty(action.Widget.Id) ? CRUDOperation.Create : CRUDOperation.Update);
        }

        //TODO automapper
        private static WidgetInput CreateInput(WidgetData widget)
        {
            var input = new WidgetInput
            {
                Id = widget.Id,
                Name = widget.Name,
                Type = widget.Type,
                Labels = widget.Labels.Select(MapLabel).ToList(),
                ColumnMappings = widget.ColumnMappings.Select(MapColumn).ToList()
            };

            return input;
        }

        //TODO automapper
        private static LabelDataInput MapLabel(ILabel label)
        {
            return new LabelDataInput
            {
                Name = label.Name,
            };
        }

        //TODO automapper
        private static ColumnMappingDataInput MapColumn(ColumnMappingData column)
        {
            return new ColumnMappingDataInput
            {
                Name = column.Name,
                Format = column.Format,
                DataSourceId = column.DataSourceId,
                SourceColumn = column.SourceColumn
            };
        }
    }
}
