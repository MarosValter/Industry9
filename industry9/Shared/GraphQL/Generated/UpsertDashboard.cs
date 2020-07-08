using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertDashboard
        : IUpsertDashboard
    {
        public UpsertDashboard(
            global::industry9.Shared.IDashboardId createDashboard)
        {
            CreateDashboard = createDashboard;
        }

        public global::industry9.Shared.IDashboardId CreateDashboard { get; }
    }
}
