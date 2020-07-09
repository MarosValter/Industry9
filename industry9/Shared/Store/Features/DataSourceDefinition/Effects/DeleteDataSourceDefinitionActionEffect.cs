using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fluxor;
using industry9.Shared.Store.Features.DataSourceDefinition.Actions;

namespace industry9.Shared.Store.Features.DataSourceDefinition.Effects
{
    public class DeleteDataSourceDefinitionActionEffect : Effect<DeleteDataSourceDefinitionAction>
    {
        private readonly IIndustry9Client _client;

        public DeleteDataSourceDefinitionActionEffect(IIndustry9Client client)
        {
            _client = client;
        }

        protected override async Task HandleAsync(DeleteDataSourceDefinitionAction action, IDispatcher dispatcher)
        {
            
        }
    }
}
