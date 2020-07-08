namespace industry9.Shared.Store.DataSourceDefinition
{
    public class UpsertDataSourceDefinitionAction
    {
        public IDataSourceDefinitionDetail DataSourceDefinition { get; set; }

        public UpsertDataSourceDefinitionAction(IDataSourceDefinitionDetail dataSourceDefinition)
        {
            DataSourceDefinition = dataSourceDefinition;
        }
    }
}
