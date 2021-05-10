namespace industry9.Client.Data.Store.States
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
