﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IDashboardWidget
    {
        string WidgetId { get; }

        global::industry9.Shared.IWidgetId Widget { get; }

        string Size { get; }

        string Position { get; }
    }
}
