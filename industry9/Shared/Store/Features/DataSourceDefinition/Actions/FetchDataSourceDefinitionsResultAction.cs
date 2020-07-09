using System.Collections.Generic;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Actions
{
    public class FetchDataSourceDefinitionsResultAction
    {
        public FetchDataSourceDefinitionsResultAction(IEnumerable<IDataSourceDefinitionLite> definitions)
        {
            Definitions = definitions;
        }

        public IEnumerable<IDataSourceDefinitionLite> Definitions { get; }
    }
}
