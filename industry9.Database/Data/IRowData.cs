using System.Collections.Generic;

namespace industry9.Database.Data
{
    public interface IRowData
    {
        IList<ColumnData> Columns { get; }
    }
}
