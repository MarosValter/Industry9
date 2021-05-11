﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class RandomDataSourcePropertiesInput : global::industry9.Client.Data.GraphQL.Generated.State.IRandomDataSourcePropertiesInputInfo, global::System.IEquatable<RandomDataSourcePropertiesInput>
    {
        public override global::System.Boolean Equals(global::System.Object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((RandomDataSourcePropertiesInput)obj);
        }

        public virtual global::System.Boolean Equals(RandomDataSourcePropertiesInput? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return (Min == other.Min) && Max == other.Max;
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                hash ^= 397 * Min.GetHashCode();
                hash ^= 397 * Max.GetHashCode();
                return hash;
            }
        }

        private global::System.Int32 _value_min;
        private global::System.Boolean _set_min;
        private global::System.Int32 _value_max;
        private global::System.Boolean _set_max;
        public global::System.Int32 Min
        {
            get => _value_min;
            set
            {
                _set_min = true;
                _value_min = value;
            }
        }

        global::System.Boolean global::industry9.Client.Data.GraphQL.Generated.State.IRandomDataSourcePropertiesInputInfo.IsMinSet => _set_min;
        public global::System.Int32 Max
        {
            get => _value_max;
            set
            {
                _set_max = true;
                _value_max = value;
            }
        }

        global::System.Boolean global::industry9.Client.Data.GraphQL.Generated.State.IRandomDataSourcePropertiesInputInfo.IsMaxSet => _set_max;
    }
}
