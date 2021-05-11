﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetDashboardResultInfo : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly global::System.UInt64 _version;
        public GetDashboardResultInfo(global::StrawberryShake.EntityId dashboard, global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds, global::System.UInt64 version)
        {
            Dashboard = dashboard;
            _entityIds = entityIds ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::StrawberryShake.EntityId Dashboard { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;
        public global::System.UInt64 Version => _version;
        public global::StrawberryShake.IOperationResultDataInfo WithVersion(global::System.UInt64 version)
        {
            return new GetDashboardResultInfo(Dashboard, _entityIds, version);
        }
    }
}
