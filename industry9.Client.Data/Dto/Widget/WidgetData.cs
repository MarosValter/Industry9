using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace industry9.Client.Data.Dto.Widget
{
    public class WidgetData
    {
        public string Id { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public WidgetType Type { get; set; }

        public List<LabelData> Labels { get; set; }

        public List<ColumnMappingData> ColumnMappings { get; set; }

        public WidgetData()
        {
            Created = DateTime.Now;
            Labels = new List<LabelData>();
            ColumnMappings = new List<ColumnMappingData>();
        }
    }
}
