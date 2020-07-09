using System.Linq;
using Fluxor;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.DataSourceDefinition
{
    public class DataSourceDefinitionFeature : Feature<DataSourceDefinitionState>
    {
        public override string GetName() => "DataSourceDefinitions";

        protected override DataSourceDefinitionState GetInitialState() => new DataSourceDefinitionState(Enumerable.Empty<IDataSourceDefinitionLite>(), null);
    }
}
