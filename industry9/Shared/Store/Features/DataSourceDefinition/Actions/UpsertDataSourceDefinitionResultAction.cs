namespace industry9.Shared.Store.Features.DataSourceDefinition.Actions
{
    public class UpsertDataSourceDefinitionResultAction
    {
        public bool SaveChanges { get; }
        public IDataSourceDefinitionDetail DataSourceDefinition { get; }

        public UpsertDataSourceDefinitionResultAction(IDataSourceDefinitionDetail dataSourceDefinition, bool saveChanges = false)
        {
            DataSourceDefinition = dataSourceDefinition;
            SaveChanges = saveChanges;
        }
    }
}
