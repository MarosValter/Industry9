using industry9.Shared.Dto.Widget;

namespace industry9.Shared.Store.Features.Widget.Actions
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
