﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetWidgets_Widgets_WidgetFromWidgetEntityMapper : global::StrawberryShake.IEntityMapper<global::industry9.Client.Data.GraphQL.Generated.State.WidgetEntity, GetWidgets_Widgets_Widget>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        public GetWidgets_Widgets_WidgetFromWidgetEntityMapper(global::StrawberryShake.IEntityStore entityStore)
        {
            _entityStore = entityStore ?? throw new global::System.ArgumentNullException(nameof(entityStore));
        }

        public GetWidgets_Widgets_Widget Map(global::industry9.Client.Data.GraphQL.Generated.State.WidgetEntity entity, global::StrawberryShake.IEntityStoreSnapshot? snapshot = null)
        {
            if (snapshot is null)
            {
                snapshot = _entityStore.CurrentSnapshot;
            }

            return new GetWidgets_Widgets_Widget(entity.Id, entity.Name, entity.Created, entity.Type, MapIGetWidgets_Widgets_LabelsArray(entity.Labels, snapshot));
        }

        private global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.IGetWidgets_Widgets_Labels?>? MapIGetWidgets_Widgets_LabelsArray(global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.State.LabelDataData?>? list, global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (list is null)
            {
                return null;
            }

            var labelDatas = new global::System.Collections.Generic.List<global::industry9.Client.Data.GraphQL.Generated.IGetWidgets_Widgets_Labels?>();
            foreach (global::industry9.Client.Data.GraphQL.Generated.State.LabelDataData? child in list)
            {
                labelDatas.Add(MapIGetWidgets_Widgets_Labels(child, snapshot));
            }

            return labelDatas;
        }

        private global::industry9.Client.Data.GraphQL.Generated.IGetWidgets_Widgets_Labels? MapIGetWidgets_Widgets_Labels(global::industry9.Client.Data.GraphQL.Generated.State.LabelDataData? data, global::StrawberryShake.IEntityStoreSnapshot snapshot)
        {
            if (data is null)
            {
                return null;
            }

            IGetWidgets_Widgets_Labels returnValue = default !;
            if (data?.__typename.Equals("LabelData", global::System.StringComparison.Ordinal) ?? false)
            {
                returnValue = new GetWidgets_Widgets_Labels_LabelData(data.Name);
            }
            else
            {
                throw new global::System.NotSupportedException();
            }

            return returnValue;
        }
    }
}
