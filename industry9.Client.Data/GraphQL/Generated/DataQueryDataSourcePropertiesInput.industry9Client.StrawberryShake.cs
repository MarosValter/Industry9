﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class DataQueryDataSourcePropertiesInput : global::industry9.Client.Data.GraphQL.Generated.State.IDataQueryDataSourcePropertiesInputInfo, global::System.IEquatable<DataQueryDataSourcePropertiesInput>
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

            return Equals((DataQueryDataSourcePropertiesInput)obj);
        }

        public virtual global::System.Boolean Equals(DataQueryDataSourcePropertiesInput? other)
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

            return (((Query is null && other.Query is null) || Query != null && Query.Equals(other.Query)));
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                if (Query != null)
                {
                    hash ^= 397 * Query.GetHashCode();
                }

                return hash;
            }
        }

        private global::System.String? _value_query;
        private global::System.Boolean _set_query;
        public global::System.String? Query
        {
            get => _value_query;
            set
            {
                _set_query = true;
                _value_query = value;
            }
        }

        global::System.Boolean global::industry9.Client.Data.GraphQL.Generated.State.IDataQueryDataSourcePropertiesInputInfo.IsQuerySet => _set_query;
    }
}
