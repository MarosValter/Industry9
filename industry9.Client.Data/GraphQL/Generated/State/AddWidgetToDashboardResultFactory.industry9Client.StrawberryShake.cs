﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class AddWidgetToDashboardResultFactory : global::StrawberryShake.IOperationResultDataFactory<global::industry9.Client.Data.GraphQL.Generated.AddWidgetToDashboardResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        public AddWidgetToDashboardResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::industry9.Client.Data.GraphQL.Generated.IAddWidgetToDashboardResult);
        public AddWidgetToDashboardResult Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is AddWidgetToDashboardResultInfo info)
            {
                return new AddWidgetToDashboardResult(info.AddWidgetToDashboard);
            }

            throw new global::System.ArgumentException("AddWidgetToDashboardResultInfo expected.");
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(dataInfo, snapshot);
        }
    }
}
