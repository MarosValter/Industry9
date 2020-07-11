using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class FetchQueryDataSourceProperties
        : IFetchQueryDataSourceProperties
    {
        public FetchQueryDataSourceProperties(
            global::industry9.Shared.IDataQueryDataSourceProperties fetchDataQueryPropertiesFromDataSource)
        {
            FetchDataQueryPropertiesFromDataSource = fetchDataQueryPropertiesFromDataSource;
        }

        public global::industry9.Shared.IDataQueryDataSourceProperties FetchDataQueryPropertiesFromDataSource { get; }
    }
}
