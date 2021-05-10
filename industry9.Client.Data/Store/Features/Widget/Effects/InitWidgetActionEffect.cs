using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Dto;
using industry9.Client.Data.Dto.Widget;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.Dashboard.Reducers;
using industry9.Client.Data.Store.Features.Widget.Actions;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.Widget.Effects
{
    public class InitWidgetActionEffect : Effect<InitWidgetAction>
    {
        private readonly Iindustry9Client _client;

        public InitWidgetActionEffect(Iindustry9Client client)
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

            var result = await _client.GetWidget.ExecuteAsync(action.Id);
            if (result.IsSuccessResult() && result.Data != null)
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
                Labels = widget.Labels?.Select(LabelReducer.MapLabel).ToList() ?? new List<LabelData>(),
                ColumnMappings = widget.ColumnMappings?.Select(MapColumn).ToList() ?? new List<ColumnMappingData>()
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
