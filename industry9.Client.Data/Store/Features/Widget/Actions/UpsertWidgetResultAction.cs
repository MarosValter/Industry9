using industry9.Client.Data.Dto.Widget;

namespace industry9.Client.Data.Store.Features.Widget.Actions
{
    public class UpsertWidgetResultAction
    {
        public bool SaveChanges { get; }
        public WidgetData Widget { get; }

        public UpsertWidgetResultAction(WidgetData widget, bool saveChanges = false)
        {
            Widget = widget;
            SaveChanges = saveChanges;
        }
    }
}
