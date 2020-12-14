using System.ComponentModel.DataAnnotations;
using industry9.Shared.Dto.Widget;

namespace industry9.Shared.Dto.DashboardWidget
{
    public class DashboardWidgetData : ILayoutElement
    {
        public string DashboardId { get; set; }

        [Required]
        public string WidgetId { get; set; }

        [Required]
        public SizeData Size { get; set; }

        [Required]
        public PositionData Position { get; set; }

        public WidgetData Widget { get; set; }

        public DashboardWidgetData()
        {
            Position = new PositionData(1, 1);
            Size = new SizeData(1, 1);
            Widget = new WidgetData();
        }
    }
}
