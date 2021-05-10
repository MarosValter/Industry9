﻿using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using industry9.DataModel.UI.Documents;
using industry9.GraphQL.UI.DataLoaders;
using MongoDB.Driver;

namespace industry9.GraphQL.UI.Queries
{
    [ExtendObjectType("Query")]
    public class DataSourceDefinitionQueries
    {
        //[UsePaging]
        //[UseSorting]
        //[UseFiltering]
        public IExecutable<DataSourceDefinitionDocument> GetDataSourceDefinitions([Service] IMongoCollection<DataSourceDefinitionDocument> collection)
        {
            return collection.AsExecutable();
        }

        public Task<DataSourceDefinitionDocument> GetDataSourceDefinition([ID(nameof(DataSourceDefinitionDocument))]string id, DataSourceDefinitionDataLoader loader, CancellationToken token)
        {
            return loader.LoadAsync(id, token);
        }
    }
}
