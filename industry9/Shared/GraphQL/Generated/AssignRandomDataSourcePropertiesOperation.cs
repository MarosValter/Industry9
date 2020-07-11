using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class AssignRandomDataSourcePropertiesOperation
        : IOperation<IAssignRandomDataSourceProperties>
    {
        public string Name => "assignRandomDataSourceProperties";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IAssignRandomDataSourceProperties);

        public Optional<string> DefinitionId { get; set; }

        public Optional<global::industry9.Shared.RandomDataSourcePropertiesInput> Properties { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (DefinitionId.HasValue)
            {
                variables.Add(new VariableValue("definitionId", "String", DefinitionId.Value));
            }

            if (Properties.HasValue)
            {
                variables.Add(new VariableValue("properties", "RandomDataSourcePropertiesInput", Properties.Value));
            }

            return variables;
        }
    }
}
