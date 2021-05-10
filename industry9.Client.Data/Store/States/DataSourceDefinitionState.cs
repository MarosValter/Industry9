using System.Collections.Generic;
using System.Linq;
using industry9.Client.Data.Dto.DataSourceDefinition;
using industry9.Client.Data.Dto.DataSourceDefinition.Properties;
using industry9.Client.Data.Store.Base;

namespace industry9.Client.Data.Store.States
{
    public class DataSourceDefinitionState : IEditableState<DataSourceDefinitionData>
    {
        public IEnumerable<IDataSourceDefinitionLite> Definitions { get; }
        public DataSourceDefinitionData EditedObject { get; }
        public IDataSourcePropertiesData EditedProperties { get; }

        public DataSourceDefinitionState(
            IEnumerable<IDataSourceDefinitionLite> definitions,
            DataSourceDefinitionData editedObject)
        {
            Definitions = definitions ?? Enumerable.Empty<IDataSourceDefinitionLite>();
            EditedObject = editedObject;
            EditedProperties = editedObject.Properties;
        }
    }
}
