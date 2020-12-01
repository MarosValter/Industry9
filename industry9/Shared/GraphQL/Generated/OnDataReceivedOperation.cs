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

        public Optional<string> DataSourceId { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (DataSourceId.HasValue)
            {
                variables.Add(new VariableValue("dataSourceId", "String", DataSourceId.Value));
            }

            return variables;
        }
    }
}
