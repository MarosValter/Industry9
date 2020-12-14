using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class RemoveWidgetFromDashboardOperation
        : IOperation<IRemoveWidgetFromDashboard>
    {
        public string Name => "removeWidgetFromDashboard";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IRemoveWidgetFromDashboard);

        public Optional<string> DashboardId { get; set; }

        public Optional<string> WidgetId { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (DashboardId.HasValue)
            {
                variables.Add(new VariableValue("dashboardId", "String", DashboardId.Value));
            }

            if (WidgetId.HasValue)
            {
                variables.Add(new VariableValue("widgetId", "String", WidgetId.Value));
            }

            return variables;
        }
    }
}
