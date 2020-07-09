namespace industry9.Shared.Store.Features.DataSourceDefinition.Actions
{
    public class DeleteDataSourceDefinitionAction
    {
        public string Id { get; }

        public DeleteDataSourceDefinitionAction(string id)
        {
            Id = id;
        }
    }
}
