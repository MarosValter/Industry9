using System.Collections.Generic;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Actions
{
    public class FetchDataSourceDefinitionsResultAction
    {
        public IEnumerable<IDataSourceDefinitionLite> Definitions { get; }

        public FetchDataSourceDefinitionsResultAction(IEnumerable<IDataSourceDefinitionLite> definitions)
        {
            Definitions = definitions;
        }
    }
}
