﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class LabelDataInput : global::industry9.Client.Data.GraphQL.Generated.State.ILabelDataInputInfo, global::System.IEquatable<LabelDataInput>
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

            return Equals((LabelDataInput)obj);
        }

        public virtual global::System.Boolean Equals(LabelDataInput? other)
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

        private global::System.String? _value_name;
        private global::System.Boolean _set_name;
        public global::System.String? Name
        {
            get => _value_name;
            set
            {
                _set_name = true;
                _value_name = value;
            }
        }

        global::System.Boolean global::industry9.Client.Data.GraphQL.Generated.State.ILabelDataInputInfo.IsNameSet => _set_name;
    }
}
