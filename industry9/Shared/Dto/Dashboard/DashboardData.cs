using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using industry9.Shared.Dto.DashboardWidget;

namespace industry9.Shared.Dto.Dashboard
{
    public class DashboardData
    {
        public string Id { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public string Name { get; set; }

        public string AuthorId { get; set; }

        public List<ILabel> Labels { get; set; }

        public List<DashboardWidgetData> Widgets { get; set; }

        public DashboardData()
        {
            Labels = new List<ILabel>();
            Widgets = new List<DashboardWidgetData>();
        }

        public DashboardData(string id, string name, string authorId, DateTime created, List<ILabel> labels, List<DashboardWidgetData> widgets)
        {
            Id = id;
            Name = name;
            AuthorId = authorId;
            Created = created;
            Labels = labels ?? new List<ILabel>();
            Widgets = widgets ?? new List<DashboardWidgetData>();
        }
    }
}
