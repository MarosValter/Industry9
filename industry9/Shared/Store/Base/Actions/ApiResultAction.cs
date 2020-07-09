namespace industry9.Shared.Store.Base.Actions
{
    public class ApiResultAction
    {
        public string Title { get; }
        public string Message { get; }
        public ToastType Type { get; }

        public ApiResultAction(string message, ToastType type, string title = null)
        {
            Title = title;
            Message = message;
            Type = type;
        }
    }
}
