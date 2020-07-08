using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class UpsertDataSourceDefinitionOperation
        : IOperation<IUpsertDataSourceDefinition>
    {
        public string Name => "upsertDataSourceDefinition";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IUpsertDataSourceDefinition);

        public Optional<global::industry9.Shared.DataSourceDefinitionInput> Definition { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Definition.HasValue)
            {
                variables.Add(new VariableValue("definition", "DataSourceDefinitionInput", Definition.Value));
            }

            return variables;
        }
    }
}
