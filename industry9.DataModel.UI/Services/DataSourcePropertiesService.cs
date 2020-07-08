using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using industry9.Common.Enums;
using industry9.Common.GraphQL;
using industry9.DataModel.UI.Documents;

namespace industry9.DataModel.UI.Services
{
    public class DataSourcePropertiesService : IDataSourcePropertiesService
    {
        private IDictionary<DataSourceType, Type> _typesMap;

        public IList<Type> Types => _typesMap.Values.ToList();

        public void ScanForProperties(Assembly[] assemblies)
        {
            var propertyTypes = assemblies.SelectMany(x => x.ExportedTypes.Where(t => typeof(IDataSourceProperties).IsAssignableFrom(t) && t.GetCustomAttribute<DataSourcePropertiesAttribute>() != null));
            _typesMap = propertyTypes.ToDictionary(k => k.GetCustomAttribute<DataSourcePropertiesAttribute>().Type);
        }

        public Type GetPropertiesType(DataSourceType type)
        {
            if (!_typesMap.ContainsKey(type))
            {
                throw new ArgumentException($"No properties registered for type {type}", nameof(type));
            }

            return _typesMap[type];
        }
    }
}
