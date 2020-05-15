namespace industry9.Shared.Navigation
{
    public class LinkItem
    {
        public string Title { get; set; }
        public string RelativePath { get; set; }
        public string AbsolutePath { get; set; }

        public LinkItem(string title, string relativePath, string absolutePath)
        {
            Title = title;
            RelativePath = relativePath;
            AbsolutePath = absolutePath;
        }
    }
}
