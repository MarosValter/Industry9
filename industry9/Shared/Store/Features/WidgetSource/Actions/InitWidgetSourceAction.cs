namespace industry9.Shared.Store.Features.WidgetSource.Actions
{
    public class InitWidgetSourceAction
    {
        public string Id { get; }
        public bool Subscribe { get; }

        public InitWidgetSourceAction(string id, bool subscribe)
        {
            Id = id;
            Subscribe = subscribe;
        }
    }
}
