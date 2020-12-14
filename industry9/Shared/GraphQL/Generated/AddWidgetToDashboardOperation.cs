using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AddWidgetToDashboardOperation
        : IOperation<IAddWidgetToDashboard>
    {
        public string Name => "addWidgetToDashboard";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IAddWidgetToDashboard);

        public Optional<global::industry9.Shared.DashboardWidgetInput> DashboardWidget { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (DashboardWidget.HasValue)
            {
                variables.Add(new VariableValue("dashboardWidget", "DashboardWidgetInput", DashboardWidget.Value));
            }

            return variables;
        }
    }
}
