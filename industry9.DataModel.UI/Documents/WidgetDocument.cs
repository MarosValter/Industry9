﻿using System.Collections.Generic;
using industry9.Common.Enums;
using industry9.Common.Structs;

namespace industry9.DataModel.UI.Documents
{
    public class WidgetDocument : BaseDocument
    {
        public WidgetDocument()
        {
            Labels = new List<LabelData>();
            ColumnMappings = new List<ColumnMappingData>();
        }

        public string Name { get; set; }

        public WidgetType Type { get; set; }

        //public TimeSettings TimeSettings { get; set; }

        public IReadOnlyList<LabelData> Labels { get; set; }

        public IReadOnlyList<ColumnMappingData> ColumnMappings { get; set; }
    }
}
