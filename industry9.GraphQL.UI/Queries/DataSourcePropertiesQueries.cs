using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataSource.PropertiesData;
using industry9.GraphQL.UI.DataLoaders;

namespace industry9.GraphQL.UI.Queries
{
    [ExtendObjectType("Query")]
    public class DataSourcePropertiesQueries
    {
        public Task<RandomDataSourceProperties?> FetchRandomPropertiesFromDataSource(string dataSourceId,
            [Service] DataSourceDefinitionDataLoader loader, IResolverContext ctx)
            => FetchPropertiesFromDataSource<RandomDataSourceProperties>(dataSourceId, loader, ctx);

        public Task<DataQueryDataSourceProperties?> FetchDataQueryPropertiesFromDataSource(string dataSourceId,
            [Service] DataSourceDefinitionDataLoader loader, IResolverContext ctx)
            => FetchPropertiesFromDataSource<DataQueryDataSourceProperties>(dataSourceId, loader, ctx);

        private async Task<TProperties?> FetchPropertiesFromDataSource<TProperties>(string dataSourceId,
            [Service] DataSourceDefinitionDataLoader loader, IResolverContext ctx)
            where TProperties : class, IDataSourceProperties
        {
            var definition = await loader.LoadAsync(dataSourceId, ctx.RequestAborted);

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
