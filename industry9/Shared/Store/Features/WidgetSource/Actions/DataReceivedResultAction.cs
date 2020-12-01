namespace industry9.Shared.Store.Features.WidgetSource.Actions
{
    public class DataReceivedResultAction
    {
        public string Id { get; }
        public ISensorData NewData { get; }

        public DataReceivedResultAction(string id, ISensorData newData)
        {
            Id = id;
            NewData = newData;
        }
    }
}
