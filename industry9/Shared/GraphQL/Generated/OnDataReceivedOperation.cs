using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnDataReceivedOperation
        : IOperation<IOnDataReceived>
    {
        public string Name => "onDataReceived";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Subscription;

        public Type ResultType => typeof(IOnDataReceived);

        public Optional<string> WidgetId { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (WidgetId.HasValue)
            {
                variables.Add(new VariableValue("widgetId", "String", WidgetId.Value));
            }

            return variables;
        }
    }
}
