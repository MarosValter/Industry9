using System.Linq;

namespace industry9.Shared.Store.States
{
    public class WidgetSourceState
    {
        public WidgetSourceState(ILookup<string, ISensorData> widgetData)
        {
            WidgetData = widgetData;
        }

        public ILookup<string, ISensorData> WidgetData { get; }
    }
}
