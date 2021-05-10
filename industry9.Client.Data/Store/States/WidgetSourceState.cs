using System.Linq;
using industry9.Client.Data.Dto.Message;

namespace industry9.Client.Data.Store.States
{
    public class WidgetSourceState
    {
        public WidgetSourceState(ILookup<string, MessageData> widgetData)
        {
            WidgetData = widgetData;
        }

        public ILookup<string, MessageData> WidgetData { get; }
    }
}
