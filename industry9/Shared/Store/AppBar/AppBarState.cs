namespace industry9.Shared.Store.AppBar
{
    public class AppBarState
    {
        public string Title { get; }
        public string Color { get; }

        public AppBarState(string title, string color)
        {
            Title = title;
            Color = color;
        }
    }
}
