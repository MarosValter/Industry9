﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetDashboards_Dashboards_DashboardFromDashboardEntityMapper : global::StrawberryShake.IEntityMapper<global::industry9.Client.Data.GraphQL.Generated.State.DashboardEntity, GetDashboards_Dashboards_Dashboard>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        public GetDashboards_Dashboards_DashboardFromDashboardEntityMapper(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        public GetDashboards_Dashboards_Dashboard Map(global::industry9.Client.Data.GraphQL.Generated.State.DashboardEntity entity, global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            return new GetDashboards_Dashboards_Dashboard(entity.Id, entity.Name, entity.Private, entity.AuthorId, entity.Created, MapIGetDashboards_Dashboards_LabelsArray(entity.Labels, snapshot));
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.IGetDashboards_Dashboards_Labels?>? MapIGetDashboards_Dashboards_LabelsArray(global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.State.LabelDataData?>? list, global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (list is null)
            {
                return null;
            }

            var labelDatas = new global::System.Collections.Generic.List<global::industry9.Client.Data.GraphQL.Generated.IGetDashboards_Dashboards_Labels?>();
            foreach (global::industry9.Client.Data.GraphQL.Generated.State.LabelDataData? child in list)
            {
                labelDatas.Add(MapIGetDashboards_Dashboards_Labels(child, snapshot));
            }

            return labelDatas;
        }

        private global::industry9.Client.Data.GraphQL.Generated.IGetDashboards_Dashboards_Labels? MapIGetDashboards_Dashboards_Labels(global::industry9.Client.Data.GraphQL.Generated.State.LabelDataData? data, global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (data is null)
            {
                return null;
            }

            IGetDashboards_Dashboards_Labels returnValue = default !;
            if (data?.__typename.Equals("LabelData", global::System.StringComparison.Ordinal) ?? false)
            {
                returnValue = new GetDashboards_Dashboards_Labels_LabelData(data.Name);
            }
            else
            {
                throw new global::System.NotSupportedException();
            }

            return returnValue;
        }
    }
}
