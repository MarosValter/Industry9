﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetDashboardsResult : global::System.IEquatable<GetDashboardsResult>, IGetDashboardsResult
    {
        public GetDashboardsResult(global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.IGetDashboards_Dashboards> dashboards)
        {
            Dashboards = dashboards;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::industry9.Client.Data.GraphQL.Generated.IGetDashboards_Dashboards> Dashboards { get; }

        public virtual global::System.Boolean Equals(GetDashboardsResult? other)
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

            return (global::StrawberryShake.Helper.ComparisonHelper.SequenceEqual(Dashboards, other.Dashboards));
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

            return Equals((GetDashboardsResult)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                foreach (var Dashboards_elm in Dashboards)
                {
                    hash ^= 397 * Dashboards_elm.GetHashCode();
                }

                return hash;
            }
        }
    }
}
