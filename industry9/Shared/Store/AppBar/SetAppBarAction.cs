namespace industry9.Shared.Store.AppBar
{
    public class SetAppBarAction
    {
        public string Title { get; }
        public string Color { get; }

        public SetAppBarAction(string title, string color)
        {
            Title = title;
            Color = color;
        }
    }
}
