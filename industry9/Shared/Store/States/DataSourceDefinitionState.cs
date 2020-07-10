using System.Collections.Generic;
using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.States
{
    public class DataSourceDefinitionState : IEditableState<IDataSourceDefinitionDetail>
    {
        public IEnumerable<IDataSourceDefinitionLite> Definitions { get; }
        public IDataSourceDefinitionDetail EditedObject { get; }

        public DataSourceDefinitionState(IEnumerable<IDataSourceDefinitionLite> definitions, IDataSourceDefinitionDetail editedObject)
        {
            Definitions = definitions;
            EditedObject = editedObject;
        }
    }
}
