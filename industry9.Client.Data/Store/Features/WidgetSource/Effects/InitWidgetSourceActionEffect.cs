﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Fluxor;
using industry9.Client.Data.Dto.Message;
using industry9.Client.Data.GraphQL.Generated;
using industry9.Client.Data.Store.Extensions;
using industry9.Client.Data.Store.Features.WidgetSource.Actions;
using Microsoft.Extensions.Logging;
using StrawberryShake;

namespace industry9.Client.Data.Store.Features.WidgetSource.Effects
{
    public class InitWidgetSourceActionEffect : Effect<InitWidgetSourceAction>
    {
        private readonly Iindustry9Client _client;
        private readonly ILogger<InitWidgetSourceActionEffect> _logger;

        public InitWidgetSourceActionEffect(Iindustry9Client client, ILogger<InitWidgetSourceActionEffect> logger)
        {
            _client = client;
            _logger = logger;
        }

        protected override async Task HandleAsync(InitWidgetSourceAction action, IDispatcher dispatcher)
        {
            var widgetResult = await _client.GetWidget.ExecuteAsync(action.WidgetId);

            if (widgetResult.IsErrorResult() || widgetResult.Data == null)
            {
                widgetResult.DispatchToast(dispatcher, null, $"Unable to fetch Widget {action.WidgetId}");
                return;
            }

            // TODO fetch sensor data
            dispatcher.Dispatch(new DataReceivedResultAction(action.WidgetId, new List<MessageData>()));

            //if (action.Subscribe)
            //{
            //    _logger.LogInformation("Subscribing widget {0}", action.WidgetId);
            //    var tasks = widgetResult.Data.Widget.ColumnMappings.Select(c => c.DataSourceId)
            //                            .Distinct()
            //                            .Select(dataSourceId => Task.Run(async () =>
            //                            {
            //                                await foreach (var dataResult in await _client.OnDataReceived.Async(dataSourceId))
            //                                {
            //                                    _logger.LogInformation("New data {0}",
            //                                        JsonSerializer.Serialize(dataResult.Data?.OnDataReceived));
            //                                    if (!dataResult.HasErrors && dataResult.Data != null)
            //                                    {
            //                                        var columnMapping =
            //                                            widgetResult.Data.Widget.ColumnMappings.FirstOrDefault(c =>
            //                                                c.DataSourceId == dataResult.Data.OnDataReceived.DataSourceId &&
            //                                                c.SourceColumn == dataResult.Data.OnDataReceived.Name);

            //                                        if (columnMapping != null)
            //                                        {
            //                                            _logger.LogInformation("Data dispatched for dataSource {0}", dataSourceId);
            //                                            dispatcher.Dispatch(new DataReceivedResultAction(action.WidgetId, new List<ISensorData>{ dataResult.Data.OnDataReceived }));
            //                                        }
            //                                    }
            //                                }
            //                            }))
            //                            .ToList();

            //    await Task.WhenAll(tasks);
            //}
        }
    }
}
