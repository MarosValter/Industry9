using System.Collections.Generic;

namespace industry9.Shared.Store.States
{
    public class WidgetSourceState
    {
        public WidgetSourceState(IWidgetDetail widget, IReadOnlyCollection<ISensorData> data)
        {
            Widget = widget;
            Data = data;
        }

        public IWidgetDetail Widget { get; }
        public IReadOnlyCollection<ISensorData> Data { get; }
    }
}
