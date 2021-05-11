using System.Collections.Generic;
using System.Linq;
using industry9.Client.Data.GraphQL.Generated;

namespace industry9.Client.Data.Store.Features.DataSourceDefinition.Actions
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
