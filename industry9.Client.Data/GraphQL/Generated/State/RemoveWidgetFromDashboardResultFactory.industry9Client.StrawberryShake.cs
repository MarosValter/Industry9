﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class RemoveWidgetFromDashboardResultFactory : global::StrawberryShake.IOperationResultDataFactory<global::industry9.Client.Data.GraphQL.Generated.RemoveWidgetFromDashboardResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        public RemoveWidgetFromDashboardResultFactory(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        global::System.Type global::StrawberryShake.IOperationResultDataFactory.ResultType => typeof(global::industry9.Client.Data.GraphQL.Generated.IRemoveWidgetFromDashboardResult);
        public RemoveWidgetFromDashboardResult Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            if (dataInfo is RemoveWidgetFromDashboardResultInfo info)
            {
                return new RemoveWidgetFromDashboardResult(info.RemoveWidgetFromDashboard);
            }

            throw new global::System.ArgumentException("RemoveWidgetFromDashboardResultInfo expected.");
        }

        global::System.Object global::StrawberryShake.IOperationResultDataFactory.Create(global::StrawberryShake.IOperationResultDataInfo dataInfo, global::StrawberryShake.IEntityStoreSnapshot? snapshot)
        {
            return Create(dataInfo, snapshot);
        }
    }
}
