namespace industry9.Client.Data.Store.Features.WidgetSource.Actions
{
    public class InitWidgetSourceAction
    {
        public string WidgetId { get; }
        public bool Subscribe { get; }

        public InitWidgetSourceAction(string widgetId, bool subscribe)
        {
            WidgetId = widgetId;
            Subscribe = subscribe;
        }
    }
}
