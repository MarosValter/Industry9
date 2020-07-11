using industry9.Shared.Dto.DataSourceDefinition;
using industry9.Shared.Dto.DataSourceDefinition.Properties;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Actions
{
    public class UpsertDataSourceDefinitionResultAction
    {
        public bool SaveChanges { get; }
        public DataSourceDefinitionData DataSourceDefinition { get; }
        //public IDataSourcePropertiesData Properties { get; }

        public UpsertDataSourceDefinitionResultAction(
            DataSourceDefinitionData dataSourceDefinition,
            //IDataSourcePropertiesData properties,
            bool saveChanges = false)
        {
            DataSourceDefinition = dataSourceDefinition;
            //Properties = properties;
            SaveChanges = saveChanges;
        }
    }
}
