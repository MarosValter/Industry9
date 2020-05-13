using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetDashboards
        : IGetDashboards
    {
        public GetDashboards(
            global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IDashboard1> dashboards)
        {
            Dashboards = dashboards;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Shared.IDashboard1> Dashboards { get; }
    }
}
