using System.Collections.Generic;

namespace industry9.Shared.Store.Features.WidgetSource.Actions
{
    public class WidgetSourceResultAction
    {
        public IWidgetDetail Widget { get; }
        public IReadOnlyCollection<ISensorData> Data { get; }

        public WidgetSourceResultAction(IWidgetDetail widget, IReadOnlyCollection<ISensorData> data)
        {
            Widget = widget;
            Data = data;
        }
    }
}
