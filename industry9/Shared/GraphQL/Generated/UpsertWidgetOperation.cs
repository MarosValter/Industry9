using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertWidgetOperation
        : IOperation<IUpsertWidget>
    {
        public string Name => "upsertWidget";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IUpsertWidget);

        public Optional<global::industry9.Shared.WidgetInput> Widget { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Widget.HasValue)
            {
                variables.Add(new VariableValue("widget", "WidgetInput", Widget.Value));
            }

            return variables;
        }
    }
}
