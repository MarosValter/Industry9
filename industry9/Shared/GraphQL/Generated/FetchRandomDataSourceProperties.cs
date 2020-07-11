using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class FetchRandomDataSourceProperties
        : IFetchRandomDataSourceProperties
    {
        public FetchRandomDataSourceProperties(
            global::industry9.Shared.IRandomDataSourceProperties fetchRandomPropertiesFromDataSource)
        {
            FetchRandomPropertiesFromDataSource = fetchRandomPropertiesFromDataSource;
        }

        public global::industry9.Shared.IRandomDataSourceProperties FetchRandomPropertiesFromDataSource { get; }
    }
}
