using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.DataSourceDefinition;
using industry9.DataSource.PropertiesData;

namespace industry9.GraphQL.UI.Mutations
{
    [ExtendObjectType("Mutation")]
    public class DataSourcePropertiesMutations
    {
        public Task<bool> AssignRandomPropertiesToDataSource(string dataSourceId, RandomDataSourceProperties properties,
            [Service] IDataSourceDefinitionRepository dataSourceDefinitionRepository, IResolverContext ctx)
            => AssignPropertiesToDataSourceInternal(dataSourceId, properties, dataSourceDefinitionRepository, ctx);

        public Task<bool> AssignDataQueryPropertiesToDataSource(string dataSourceId, DataQueryDataSourceProperties properties,
            [Service] IDataSourceDefinitionRepository dataSourceDefinitionRepository, IResolverContext ctx)
            => AssignPropertiesToDataSourceInternal(dataSourceId, properties, dataSourceDefinitionRepository, ctx);

        private static async Task<bool> AssignPropertiesToDataSourceInternal(string dataSourceId, IDataSourceProperties properties,
            IDataSourceDefinitionRepository dataSourceDefinitionRepository, IResolverContext ctx)
        {
            var dataSource = await dataSourceDefinitionRepository.GetDocumentAsync(dataSourceId, ctx.RequestAborted);
            if (dataSource == null)
            {
                ctx.ReportError($"DataSourceDefinition with Id {dataSourceId} not found.");
                return false;
            }

            var result = await dataSourceDefinitionRepository.AssignProperties(dataSourceId, properties, ctx.RequestAborted);
            return result.IsAcknowledged;
        }
    }
}
