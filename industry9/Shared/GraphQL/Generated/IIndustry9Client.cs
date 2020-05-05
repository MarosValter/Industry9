using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IIndustry9Client
    {
        Task<IOperationResult<global::industry9.Shared.IGetDashboard>> GetDashboardAsync(
            Optional<string> id = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::industry9.Shared.IGetDashboard>> GetDashboardAsync(
            GetDashboardOperation operation,
            CancellationToken cancellationToken = default);
    }
}
