using System.Collections.Generic;

namespace industry9.Shared.Store.States
{
    public class DataSourceDefinitionState
    {
        public IEnumerable<IDataSourceDefinitionLite> Definitions { get; }
        public IDataSourceDefinitionDetail EditedDefinition { get; }

        public DataSourceDefinitionState(IEnumerable<IDataSourceDefinitionLite> definitions, IDataSourceDefinitionDetail editedDefinition)
        {
            Definitions = definitions;
            EditedDefinition = editedDefinition;
        }
    }
}
