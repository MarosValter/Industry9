using System.Collections.Generic;

namespace industry9.Shared.Store.Features.WidgetSource.Actions
{
    public class DataReceivedResultAction
    {
        public string WidgetId { get; }
        public IReadOnlyCollection<ISensorData> Data { get; }

        public DataReceivedResultAction(string widgetId, IReadOnlyCollection<ISensorData> newData)
        {
            WidgetId = widgetId;
            Data = newData;
        }
    }
}
