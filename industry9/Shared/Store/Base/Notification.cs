namespace industry9.Shared.Store.Base
{
    public class Notification
    {
        public string Title { get; }
        public string Message { get; }
        public ToastType Type { get; }

        public Notification(string message, ToastType type, string title = null)
        {
            Message = message;
            Type = type;
            Title = title;
        }
    }
}
