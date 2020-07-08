using System;
using industry9.Common.Enums;

namespace industry9.Common.GraphQL
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class DataSourcePropertiesAttribute : Attribute
    {
        public DataSourceType Type { get; set; }

        public DataSourcePropertiesAttribute(DataSourceType type)
        {
            Type = type;
        }
    }
}
