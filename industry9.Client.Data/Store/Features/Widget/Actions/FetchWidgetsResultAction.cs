﻿using System.Collections.Generic;
using System.Linq;
using industry9.Client.Data.GraphQL.Generated;

namespace industry9.Client.Data.Store.Features.Widget.Actions
{
    public class FetchWidgetsResultAction
    {
        public IEnumerable<IWidgetLite> Widgets { get; }

        public FetchWidgetsResultAction(IEnumerable<IWidgetLite> widgets)
        {
            Widgets = widgets ?? Enumerable.Empty<IWidgetLite>();
        }
    }
}
