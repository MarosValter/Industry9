﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetDataSourceDefinitionsResult : global::System.IEquatable<GetDataSourceDefinitionsResult>, IGetDataSourceDefinitionsResult
    {
        public GetDataSourceDefinitionsResult(global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.IGetDataSourceDefinitions_DataSourceDefinitions> dataSourceDefinitions)
        {
            DataSourceDefinitions = dataSourceDefinitions;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.IGetDataSourceDefinitions_DataSourceDefinitions> DataSourceDefinitions { get; }

        public virtual global::System.Boolean Equals(GetDataSourceDefinitionsResult? other)
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

            return (global::StrawberryShake.Helper.ComparisonHelper.SequenceEqual(DataSourceDefinitions, other.DataSourceDefinitions));
        }

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

            return Equals((GetDataSourceDefinitionsResult)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                foreach (var DataSourceDefinitions_elm in DataSourceDefinitions)
                {
                    hash ^= 397 * DataSourceDefinitions_elm.GetHashCode();
                }

                return hash;
            }
        }
    }
}
