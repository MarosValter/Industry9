﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetDataSourceDefinition_DataSourceDefinition_DataSourceDefinitionFromDataSourceDefinitionEntityMapper : global::StrawberryShake.IEntityMapper<global::industry9.Client.Data.GraphQL.Generated.State.DataSourceDefinitionEntity, GetDataSourceDefinition_DataSourceDefinition_DataSourceDefinition>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        public GetDataSourceDefinition_DataSourceDefinition_DataSourceDefinitionFromDataSourceDefinitionEntityMapper(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        public GetDataSourceDefinition_DataSourceDefinition_DataSourceDefinition Map(global::industry9.Client.Data.GraphQL.Generated.State.DataSourceDefinitionEntity entity, global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            return new GetDataSourceDefinition_DataSourceDefinition_DataSourceDefinition(entity.Id, entity.Name, entity.Created, entity.Type, entity.Inputs, MapIGetDataSourceDefinition_DataSourceDefinition_ColumnsArray(entity.Columns, snapshot));
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.IGetDataSourceDefinition_DataSourceDefinition_Columns?>? MapIGetDataSourceDefinition_DataSourceDefinition_ColumnsArray(global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.State.ExportedColumnDataData?>? list, global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (list is null)
            {
                return null;
            }

            var exportedColumnDatas = new global::System.Collections.Generic.List<global::industry9.Client.Data.GraphQL.Generated.IGetDataSourceDefinition_DataSourceDefinition_Columns?>();
            foreach (global::industry9.Client.Data.GraphQL.Generated.State.ExportedColumnDataData? child in list)
            {
                exportedColumnDatas.Add(MapIGetDataSourceDefinition_DataSourceDefinition_Columns(child, snapshot));
            }

            return exportedColumnDatas;
        }

        private global::industry9.Client.Data.GraphQL.Generated.IGetDataSourceDefinition_DataSourceDefinition_Columns? MapIGetDataSourceDefinition_DataSourceDefinition_Columns(global::industry9.Client.Data.GraphQL.Generated.State.ExportedColumnDataData? data, global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (data is null)
            {
                return null;
            }

            IGetDataSourceDefinition_DataSourceDefinition_Columns returnValue = default !;
            if (data?.__typename.Equals("ExportedColumnData", global::System.StringComparison.Ordinal) ?? false)
            {
                returnValue = new GetDataSourceDefinition_DataSourceDefinition_Columns_ExportedColumnData(data.Name, data.ValueType ?? throw new global::System.ArgumentNullException());
            }
            else
            {
                throw new global::System.NotSupportedException();
            }

            return returnValue;
        }
    }
}
