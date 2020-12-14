using System.Collections.Generic;
using System.Linq;
using industry9.Shared.Dto.DataSourceDefinition.Properties;
using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.States
{
    public class DataSourceDefinitionState : IEditableState<IDataSourceDefinitionDetail>
    {
        public IEnumerable<IDataSourceDefinitionLite> Definitions { get; }
        public IDataSourceDefinitionDetail EditedObject { get; }
        public IDataSourcePropertiesData EditedProperties { get; }

        public DataSourceDefinitionState(
            IEnumerable<IDataSourceDefinitionLite> definitions,
            IDataSourceDefinitionDetail editedObject,
            IDataSourcePropertiesData editedProperties)
        {
            Definitions = definitions ?? Enumerable.Empty<IDataSourceDefinitionLite>();
            EditedObject = editedObject;
            EditedProperties = editedProperties;
        }
    }
}
