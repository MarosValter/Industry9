using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertDashboardOperation
        : IOperation<IUpsertDashboard>
    {
        public string Name => "upsertDashboard";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IUpsertDashboard);

        public Optional<global::industry9.Shared.DashboardInput> Dashboard { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Dashboard.HasValue)
            {
                variables.Add(new VariableValue("dashboard", "DashboardInput", Dashboard.Value));
            }

            return variables;
        }
    }
}
