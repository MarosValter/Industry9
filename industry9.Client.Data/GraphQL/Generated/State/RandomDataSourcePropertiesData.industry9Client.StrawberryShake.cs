﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class RandomDataSourcePropertiesData
    {
        public RandomDataSourcePropertiesData(global::System.String __typename, global::System.Int32? min = default !, global::System.Int32? max = default !)
        {
            this.__typename = __typename ?? throw new global::System.ArgumentNullException(nameof(__typename));
            Min = min;
            Max = max;
        }

        public global::System.String __typename { get; }

        public global::System.Int32? Min { get; }

        public global::System.Int32? Max { get; }
    }
}
