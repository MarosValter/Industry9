using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace industry9.Shared.Dto.Widget
{
    public class WidgetData
    {
        public string Id { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public WidgetType Type { get; set; }

        public IList<ILabel> Labels { get; set; }

        public List<ColumnMappingData> ColumnMappings { get; set; }

        public IList<string> DataSourceIds { get; set; }

        public WidgetData()
        {
            Created = DateTime.Now;
            Labels = new List<ILabel>();
            ColumnMappings = new List<ColumnMappingData>();
            DataSourceIds = new List<string>();
        }
    }
}
