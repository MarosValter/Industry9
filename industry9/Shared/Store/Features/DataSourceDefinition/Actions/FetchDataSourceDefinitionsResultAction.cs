using System.Collections.Generic;
using System.Linq;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Actions
{
    public class FetchDataSourceDefinitionsResultAction
    {
        public IEnumerable<IDataSourceDefinitionLite> Definitions { get; }

        public FetchDataSourceDefinitionsResultAction(IEnumerable<IDataSourceDefinitionLite> definitions)
        {
            Definitions = definitions ?? Enumerable.Empty<IDataSourceDefinitionLite>();
        }
    }
}
