using industry9.Common.Enums;

namespace industry9.Database.Data
{
    public class ColumnData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public ColumnValueType ColumnType { get; set; }
    }
}
