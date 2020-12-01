using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Extensions;
using industry9.Shared.Store.Features.WidgetSource.Actions;
using Microsoft.Extensions.Logging;

namespace industry9.Shared.Store.Features.WidgetSource.Effects
{
    public class InitWidgetSourceActionEffect : Effect<InitWidgetSourceAction>
    {
        private readonly IIndustry9Client _client;
        private readonly ILogger<InitWidgetSourceActionEffect> _logger;

        public InitWidgetSourceActionEffect(IIndustry9Client client, ILogger<InitWidgetSourceActionEffect> logger)
        {
            _client = client;
            _logger = logger;
        }

        protected override async Task HandleAsync(InitWidgetSourceAction action, IDispatcher dispatcher)
        {
            var widgetResult = await _client.GetWidgetAsync(action.Id);

            if (widgetResult.HasErrors || widgetResult.Data == null)
            {
                widgetResult.DispatchToast(dispatcher, null, $"Unable to fetch Widget {action.Id}");
                return;
            }

            // TODO fetch sensor data
            dispatcher.Dispatch(new WidgetSourceResultAction(widgetResult.Data.Widget, new List<ISensorData>()));

            if (action.Subscribe)
            {
                _logger.LogInformation("Subscribing widget {0}", action.Id);
                var tasks = widgetResult.Data.Widget.ColumnMappings.Select(c => c.DataSourceId)
                                        .Distinct()
                                        .Select(dataSourceId => Task.Run(async () =>
                                        {
                                            await foreach (var dataResult in await _client.OnDataReceivedAsync(dataSourceId))
                                            {
                                                _logger.LogInformation("New data {0}",
                                                    JsonSerializer.Serialize(dataResult.Data?.OnDataReceived));
                                                if (!dataResult.HasErrors && dataResult.Data != null)
                                                {
                                                    var columnMapping =
                                                        widgetResult.Data.Widget.ColumnMappings.FirstOrDefault(c =>
                                                            c.DataSourceId == dataResult.Data.OnDataReceived.DataSourceId &&
                                                            c.SourceColumn == dataResult.Data.OnDataReceived.Name);

                                                    if (columnMapping != null)
                                                    {
                                                        _logger.LogInformation("Data dispatched for dataSource {0}", dataSourceId);
                                                        dispatcher.Dispatch(new DataReceivedResultAction(action.Id, dataResult.Data.OnDataReceived));
                                                    }
                                                }
                                            }
                                        }))
                                        .ToList();

                await Task.WhenAll(tasks);
            }
        }
    }
}
