using System.Collections.Generic;
using industry9.Client.Data.Dto.Message;

namespace industry9.Client.Data.Store.Features.WidgetSource.Actions
{
    public class DataReceivedResultAction
    {
        public string WidgetId { get; }
        public IReadOnlyCollection<MessageData> Data { get; }

        public DataReceivedResultAction(string widgetId, IReadOnlyCollection<MessageData> newData)
        {
            WidgetId = widgetId;
            Data = newData;
        }
    }
}
