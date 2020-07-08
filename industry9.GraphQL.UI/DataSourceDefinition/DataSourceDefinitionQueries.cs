using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.DataSourceDefinition;

namespace industry9.GraphQL.UI.DataSourceDefinition
{
    [ExtendObjectType(Name = "Query")]
    public class DataSourceDefinitionQueries
    {
        public IEnumerable<DataSourceDefinitionDocument> GetDataSourceDefinitions([Service] IDataSourceDefinitionRepository dataSourceDefinitionRepository)
        {
            return dataSourceDefinitionRepository.GetAllDocuments();
        }

        public async Task<DataSourceDefinitionDocument> GetDataSourceDefinition(string id, IResolverContext ctx,
            [Service] IDataSourceDefinitionRepository dataSourceDefinitionRepository)
        {
            var dataSourceDefinition = await dataSourceDefinitionRepository.GetDocumentAsync(id, ctx.RequestAborted);
            if (dataSourceDefinition == null)
            {
                ctx.ReportError($"DataSourceDefinition with Id {id} not found.");
            }

            return dataSourceDefinition;
        }
    }
}
