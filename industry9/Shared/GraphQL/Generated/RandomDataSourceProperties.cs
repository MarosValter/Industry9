using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class RandomDataSourceProperties
        : IRandomDataSourceProperties
    {
        public RandomDataSourceProperties(
            int min, 
            int max)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; }

        public int Max { get; }
    }
}
