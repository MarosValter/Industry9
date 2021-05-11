﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    /// <summary>
    /// Represents the operation service of the GetDataSourceDefinition GraphQL operation
    /// <code>
    /// query GetDataSourceDefinition($id: ID!) {
    ///   dataSourceDefinition(id: $id) {
    ///     __typename
    ///     ... DataSourceDefinitionDetail
    ///     ... on DataSourceDefinition {
    ///       id
    ///     }
    ///   }
    /// }
    /// 
    /// fragment DataSourceDefinitionDetail on DataSourceDefinition {
    ///   id
    ///   name
    ///   created
    ///   type
    ///   inputs
    ///   columns {
    ///     __typename
    ///     ... ExportedColumn
    ///   }
    /// }
    /// 
    /// fragment ExportedColumn on ExportedColumnData {
    ///   name
    ///   valueType
    /// }
    /// </code>
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetDataSourceDefinitionQuery : global::industry9.Client.Data.GraphQL.Generated.IGetDataSourceDefinitionQuery
    {
        private readonly global::StrawberryShake.IOperationExecutor<IGetDataSourceDefinitionResult> _operationExecutor;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _iDFormatter;
        public GetDataSourceDefinitionQuery(global::StrawberryShake.IOperationExecutor<IGetDataSourceDefinitionResult> operationExecutor, global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _operationExecutor = operationExecutor ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
            _iDFormatter = serializerResolver.GetInputValueFormatter("ID");
        }

        global::System.Type global::StrawberryShake.IOperationRequestFactory.ResultType => typeof(IGetDataSourceDefinitionResult);
        public async global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IGetDataSourceDefinitionResult>> ExecuteAsync(global::System.String id, global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = CreateRequest(id);
            return await _operationExecutor.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);
        }

        public global::System.IObservable<global::StrawberryShake.IOperationResult<IGetDataSourceDefinitionResult>> Watch(global::System.String id, global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest(id);
            return _operationExecutor.Watch(request, strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.String id)
        {
            var variables = new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>();
            variables.Add("id", FormatId(id));
            return CreateRequest(variables);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return new global::StrawberryShake.OperationRequest(id: GetDataSourceDefinitionQueryDocument.Instance.Hash.Value, name: "GetDataSourceDefinition", document: GetDataSourceDefinitionQueryDocument.Instance, strategy: global::StrawberryShake.RequestStrategy.Default, variables: variables);
        }

        private global::System.Object? FormatId(global::System.String value)
        {
            if (value is null)
            {
                throw new global::System.ArgumentNullException(nameof(value));
            }

            return _iDFormatter.Format(value);
        }

        global::StrawberryShake.OperationRequest global::StrawberryShake.IOperationRequestFactory.Create(global::System.Collections.Generic.IReadOnlyDictionary<global::System.String, global::System.Object?>? variables)
        {
            return CreateRequest(variables!);
        }
    }
}
