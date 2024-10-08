﻿using System.Collections.Generic;
using industry9.Client.Data.Dto.DashboardWidget;
using Microsoft.AspNetCore.Components;

namespace industry9.Client.Shared.Components.Dashboard
{
    public partial class DashboardLayoutComponent<TValue>
        where TValue : ILayoutElement
    {
        [Parameter]
        public int ColumnCount { get; set; }

        [Parameter]
        public IList<TValue> Items { get; set; }

        [Parameter]
        public RenderFragment<TValue> ItemTemplate { get; set; }

        [Parameter]
        public RenderFragment EmptyItemTemplate { get; set; }

        [Parameter]
        public string Class { get; set; }
    }
}
