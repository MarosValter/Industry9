namespace industry9.Shared.Dto.DashboardWidget
{
    public class SizeData
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public SizeData(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
