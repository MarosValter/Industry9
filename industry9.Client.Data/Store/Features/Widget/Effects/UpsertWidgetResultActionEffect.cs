using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Dto;
using industry9.Client.Data.Dto.Widget;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.Widget.Actions;
using industry9.Common.Enums;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.Widget.Effects
{
    public class UpsertWidgetActionEffect : Effect<UpsertWidgetResultAction>
    {
        private readonly Iindustry9Client _client;

        public UpsertWidgetActionEffect(Iindustry9Client client)
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
            var result = await _client.UpsertWidget.ExecuteAsync(input);

            if (result.IsSuccessResult())
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
        private static LabelDataInput MapLabel(LabelData label)
        {
            return new LabelDataInput
            {
                Name = label.Name,
            };
        }

        //TODO automapper
        private static ColumnMappingInput MapColumn(ColumnMappingData column)
        {
            return new ColumnMappingInput
            {
                Name = column.Name,
                Format = column.Format,
                DataSourceId = column.DataSourceId,
                SourceColumn = column.SourceColumn
            };
        }
    }
}
