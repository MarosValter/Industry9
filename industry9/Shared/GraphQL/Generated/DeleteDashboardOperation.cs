using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class DeleteDashboardOperation
        : IOperation<IDeleteDashboard>
    {
        public string Name => "deleteDashboard";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IDeleteDashboard);

        public Optional<string> Id { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Id.HasValue)
            {
                variables.Add(new VariableValue("id", "String", Id.Value));
            }

            return variables;
        }
    }
}
