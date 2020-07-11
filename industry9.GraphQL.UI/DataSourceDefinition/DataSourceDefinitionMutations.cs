﻿using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using industry9.DataModel.UI.Documents;
using industry9.DataModel.UI.Repositories.DataSourceDefinition;

namespace industry9.GraphQL.UI.DataSourceDefinition
{
    [ExtendObjectType(Name = "Mutation")]
    public class DataSourceDefinitionMutations
    {
        public async Task<string> UpsertDataSourceDefinition(DataSourceDefinitionDocument dataSourceDefinition,
            [Service] IDataSourceDefinitionRepository dataSourceDefinitionRepository, IResolverContext ctx)
        {
            await dataSourceDefinitionRepository.UpsertDocumentAsync(dataSourceDefinition, ctx.RequestAborted);
            return dataSourceDefinition.Id;
        }

        public async Task<bool> DeleteDataSourceDefinition(string id,
            [Service] IDataSourceDefinitionRepository dataSourceDefinitionRepository, IResolverContext ctx)
        {
            var result = await dataSourceDefinitionRepository.DeleteDocumentAsync(id, ctx.RequestAborted);
            return result.IsAcknowledged;
        }
    }
}
