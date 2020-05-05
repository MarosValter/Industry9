using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetDashboard
        : IGetDashboard
    {
        public GetDashboard(
            global::industry9.Shared.IDashboard dashboard)
        {
            Dashboard = dashboard;
        }

        public global::industry9.Shared.IDashboard Dashboard { get; }
    }
}
