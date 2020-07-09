using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Features.DataSourceDefinition.Actions;
using StrawberryShake;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Effects
{
    public class UpsertDataSourceDefinitionActionEffect : Effect<UpsertDataSourceDefinitionResultAction>
    {
        private readonly IIndustry9Client _client;

        public UpsertDataSourceDefinitionActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(UpsertDataSourceDefinitionResultAction action, IDispatcher dispatcher)
        {
            if (!action.SaveChanges)
            {
                return;
            }

            var input = new DataSourceDefinitionInput
            {
                Type = action.DataSourceDefinition.Type,
                Inputs = new Optional<IReadOnlyList<string>>(action.DataSourceDefinition.Inputs)
            };

            var result = await _client.UpsertDataSourceDefinitionAsync(input);
            if (!result.HasErrors)
            {
                dispatcher.Dispatch(new FetchDataSourceDefinitionsAction());
            }

            Console.WriteLine("Errors: {0}", JsonSerializer.Serialize(result.Errors));
        }
    }
}
