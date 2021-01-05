using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using industry9.Shared.Dto.DashboardWidget;

namespace industry9.Shared.Dto.Dashboard
{
    public class DashboardData
    {
        private int _columnCount = 4;

        public string Id { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public string Name { get; set; }

        public string AuthorId { get; set; }

        public bool Private { get; set; }

        public int ColumnCount
        {
            get => _columnCount;
            set
            {
                if (value == 5)
                {
                    if (_columnCount < 5)
                    {
                        ++value;
                    }
                    else if (_columnCount > 5)
                    {
                        --value;
                    }
                }
                _columnCount = value;
            }
        }

        public List<ILabel> Labels { get; set; }

        public List<DashboardWidgetData> Widgets { get; set; }

        public DashboardData()
        {
            Labels = new List<ILabel>();
            Widgets = new List<DashboardWidgetData>();
        }

        public DashboardData(string id, string name, int columnCount, bool @private, string authorId, DateTime created, List<ILabel> labels, List<DashboardWidgetData> widgets)
        {
            Id = id;
            Name = name;
            ColumnCount = columnCount;
            Private = @private;
            AuthorId = authorId;
            Created = created;
            Labels = labels ?? new List<ILabel>();
            Widgets = widgets ?? new List<DashboardWidgetData>();
        }
    }
}
