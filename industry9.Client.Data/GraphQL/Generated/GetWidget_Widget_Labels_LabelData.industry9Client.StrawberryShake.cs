﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetWidget_Widget_Labels_LabelData : global::System.IEquatable<GetWidget_Widget_Labels_LabelData>, IGetWidget_Widget_Labels_LabelData
    {
        public GetWidget_Widget_Labels_LabelData(global::System.String? name)
        {
            Name = name;
        }

        public global::System.String? Name { get; }

        public virtual global::System.Boolean Equals(GetWidget_Widget_Labels_LabelData? other)
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

            return (((Name is null && other.Name is null) || Name != null && Name.Equals(other.Name)));
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

            return Equals((GetWidget_Widget_Labels_LabelData)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                if (Name != null)
                {
                    hash ^= 397 * Name.GetHashCode();
                }

                return hash;
            }
        }
    }
}
