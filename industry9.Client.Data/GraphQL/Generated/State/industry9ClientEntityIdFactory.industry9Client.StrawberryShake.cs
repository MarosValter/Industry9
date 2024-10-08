﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class industry9ClientEntityIdFactory : global::StrawberryShake.IEntityIdSerializer
    {
        private static readonly global::System.Text.Json.JsonWriterOptions _options = new global::System.Text.Json.JsonWriterOptions()
        {Indented = false};
        public global::StrawberryShake.EntityId Parse(global::System.Text.Json.JsonElement obj)
        {
            global::System.String __typename = obj.GetProperty("__typename").GetString()!;
            return __typename switch
            {
            "Dashboard" => ParseDashboardEntityId(obj, __typename), "Widget" => ParseWidgetEntityId(obj, __typename), "DataSourceDefinition" => ParseDataSourceDefinitionEntityId(obj, __typename), _ => throw new global::System.NotSupportedException()}

            ;
        }

        public global::System.String Format(global::StrawberryShake.EntityId entityId)
        {
            return entityId.Name switch
            {
            "Dashboard" => FormatDashboardEntityId(entityId), "Widget" => FormatWidgetEntityId(entityId), "DataSourceDefinition" => FormatDataSourceDefinitionEntityId(entityId), _ => throw new global::System.NotSupportedException()}

            ;
        }

        private global::StrawberryShake.EntityId ParseDashboardEntityId(global::System.Text.Json.JsonElement obj, global::System.String type)
        {
            return new global::StrawberryShake.EntityId(type, obj.GetProperty("id").GetString()!);
        }

        private global::System.String FormatDashboardEntityId(global::StrawberryShake.EntityId entityId)
        {
            using var writer = new global::StrawberryShake.Internal.ArrayWriter();
            using var jsonWriter = new global::System.Text.Json.Utf8JsonWriter(writer, _options);
            jsonWriter.WriteStartObject();
            jsonWriter.WriteString("__typename", entityId.Name);
            jsonWriter.WriteString("id", (global::System.String)entityId.Value);
            jsonWriter.WriteEndObject();
            jsonWriter.Flush();
            return global::System.Text.Encoding.UTF8.GetString(writer.GetInternalBuffer(), 0, writer.Length);
        }

        private global::StrawberryShake.EntityId ParseWidgetEntityId(global::System.Text.Json.JsonElement obj, global::System.String type)
        {
            return new global::StrawberryShake.EntityId(type, obj.GetProperty("id").GetString()!);
        }

        private global::System.String FormatWidgetEntityId(global::StrawberryShake.EntityId entityId)
        {
            using var writer = new global::StrawberryShake.Internal.ArrayWriter();
            using var jsonWriter = new global::System.Text.Json.Utf8JsonWriter(writer, _options);
            jsonWriter.WriteStartObject();
            jsonWriter.WriteString("__typename", entityId.Name);
            jsonWriter.WriteString("id", (global::System.String)entityId.Value);
            jsonWriter.WriteEndObject();
            jsonWriter.Flush();
            return global::System.Text.Encoding.UTF8.GetString(writer.GetInternalBuffer(), 0, writer.Length);
        }

        private global::StrawberryShake.EntityId ParseDataSourceDefinitionEntityId(global::System.Text.Json.JsonElement obj, global::System.String type)
        {
            return new global::StrawberryShake.EntityId(type, obj.GetProperty("id").GetString()!);
        }

        private global::System.String FormatDataSourceDefinitionEntityId(global::StrawberryShake.EntityId entityId)
        {
            using var writer = new global::StrawberryShake.Internal.ArrayWriter();
            using var jsonWriter = new global::System.Text.Json.Utf8JsonWriter(writer, _options);
            jsonWriter.WriteStartObject();
            jsonWriter.WriteString("__typename", entityId.Name);
            jsonWriter.WriteString("id", (global::System.String)entityId.Value);
            jsonWriter.WriteEndObject();
            jsonWriter.Flush();
            return global::System.Text.Encoding.UTF8.GetString(writer.GetInternalBuffer(), 0, writer.Length);
        }
    }
}
