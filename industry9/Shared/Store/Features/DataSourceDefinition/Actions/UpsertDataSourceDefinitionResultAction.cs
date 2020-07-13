using industry9.Shared.Dto.DataSourceDefinition;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Actions
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
