using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AssignQueryDataSourcePropertiesOperation
        : IOperation<IAssignQueryDataSourceProperties>
    {
        public string Name => "assignQueryDataSourceProperties";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IAssignQueryDataSourceProperties);

        public Optional<string> DefinitionId { get; set; }

        public Optional<global::industry9.Shared.DataQueryDataSourcePropertiesInput> Properties { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (DefinitionId.HasValue)
            {
                variables.Add(new VariableValue("definitionId", "String", DefinitionId.Value));
            }

            if (Properties.HasValue)
            {
                variables.Add(new VariableValue("properties", "DataQueryDataSourcePropertiesInput", Properties.Value));
            }

            return variables;
        }
    }
}
