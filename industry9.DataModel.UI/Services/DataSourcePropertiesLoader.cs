using System;
using System.Linq;
using System.Reflection;
using industry9.Common.GraphQL;
using industry9.DataModel.UI.Documents;

namespace industry9.DataModel.UI.Services
{
    public class DataSourcePropertiesLoader
    {
        public static Type[] ScanForProperties(Assembly[] assemblies)
        {
            var propertyTypes = assemblies.SelectMany(x => x.ExportedTypes.Where(t => typeof(IDataSourceProperties).IsAssignableFrom(t) && t.GetCustomAttribute<DataSourcePropertiesAttribute>() != null));
            return propertyTypes.ToArray();
        }
    }
}
