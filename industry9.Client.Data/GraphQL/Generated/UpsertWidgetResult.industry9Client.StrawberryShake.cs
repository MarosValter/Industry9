﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class UpsertWidgetResult : global::System.IEquatable<UpsertWidgetResult>, IUpsertWidgetResult
    {
        public UpsertWidgetResult(global::System.String upsertWidget)
        {
            UpsertWidget = upsertWidget;
        }

        public global::System.String UpsertWidget { get; }

        public virtual global::System.Boolean Equals(UpsertWidgetResult? other)
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

            return (UpsertWidget.Equals(other.UpsertWidget));
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

            return Equals((UpsertWidgetResult)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                hash ^= 397 * UpsertWidget.GetHashCode();
                return hash;
            }
        }
    }
}
