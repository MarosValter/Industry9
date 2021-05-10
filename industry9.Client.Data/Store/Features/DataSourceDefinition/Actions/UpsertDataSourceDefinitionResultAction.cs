using industry9.Client.Data.Dto.DataSourceDefinition;

namespace industry9.Client.Data.Store.Features.DataSourceDefinition.Actions
{
    public class UpsertDataSourceDefinitionResultAction
    {
        public bool SaveChanges { get; }
        public DataSourceDefinitionData DataSourceDefinition { get; }

        public UpsertDataSourceDefinitionResultAction(DataSourceDefinitionData dataSourceDefinition, bool saveChanges = false)
        {
            DataSourceDefinition = dataSourceDefinition;
            SaveChanges = saveChanges;
        }
    }
}
