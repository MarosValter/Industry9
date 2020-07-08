using System;
using System.Collections.Generic;
using System.Reflection;
using industry9.Common.Enums;

namespace industry9.DataModel.UI.Services
{
    public interface IDataSourcePropertiesService
    {
        IList<Type> Types { get; }
        void ScanForProperties(Assembly[] assemblies);
        Type GetPropertiesType(DataSourceType type);
    }
}