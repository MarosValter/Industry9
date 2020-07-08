using System.Collections.Generic;
using System.Threading.Tasks;
using industry9.Common.Enums;
using industry9.Common.Structs;
using industry9.Database.Data;
using industry9.DataModel.UI.Documents;

namespace industry9.DataSource.Base
{
    public interface IDataSource
    {
        int Id { get; }
        DataSourceType Type { get; }
        void Initialize(DataSourceDefinitionDocument definition, TimeSettings timeSettings);
        Task<IEnumerable<IRowData>> GetData();
    }

    public interface IDataSource<out TProp> : IDataSource where TProp : IDataSourceProperties
    {
        TProp Properties { get; }
    }
}
