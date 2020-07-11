using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.DataSourceDefinition;
using industry9.DataSource.PropertiesData;

namespace industry9.GraphQL.UI.DataSourceDefinition.Properties
{
    [ExtendObjectType(Name = "Query")]
    public class DataSourcePropertiesQueries
    {
        public Task<RandomDataSourceProperties> FetchRandomPropertiesFromDataSource(string dataSourceId,
            [Service] IDataSourceDefinitionRepository dataSourceDefinitionRepository, IResolverContext ctx)
            => FetchPropertiesFromDataSource<RandomDataSourceProperties>(dataSourceId, dataSourceDefinitionRepository, ctx);

        public Task<DataQueryDataSourceProperties> FetchDataQueryPropertiesFromDataSource(string dataSourceId,
            [Service] IDataSourceDefinitionRepository dataSourceDefinitionRepository, IResolverContext ctx)
            => FetchPropertiesFromDataSource<DataQueryDataSourceProperties>(dataSourceId, dataSourceDefinitionRepository, ctx);

        private async Task<TProperties> FetchPropertiesFromDataSource<TProperties>(string dataSourceId,
            [Service] IDataSourceDefinitionRepository dataSourceDefinitionRepository, IResolverContext ctx)
            where TProperties : class, IDataSourceProperties
        {
            var definition = await dataSourceDefinitionRepository.GetDocumentAsync(dataSourceId, ctx.RequestAborted);
            if (definition == null)
            {
                ctx.ReportError($"DataSourceDefinition with Id {dataSourceId} not found.");
                return null;
            }

            if (definition.Properties == null)
            {
                return null;
            }

            if (!(definition.Properties is TProperties))
            {
                ctx.ReportError($"DataSourceDefinition properties are of invalid type. Expected type: {nameof(TProperties)}. Actual type: {definition.Properties.GetType().Name}");
                return null;
            }

            return (TProperties) definition.Properties;
        }
    }
}
