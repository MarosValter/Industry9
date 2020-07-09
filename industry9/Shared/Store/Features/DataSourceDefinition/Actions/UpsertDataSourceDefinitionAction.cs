namespace industry9.Shared.Store.Features.DataSourceDefinition.Actions
{
    public class UpsertDataSourceDefinitionAction
    {
        public string Id { get; }

        protected UpsertDataSourceDefinitionAction(string id)
        {
            Id = id;
        }
    }
}
