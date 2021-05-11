﻿// <auto-generated/>
#nullable enable

namespace industry9.Client.Data.GraphQL.Generated
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.2.2.0")]
    public partial class GetDashboard_Dashboard_Widgets_DashboardWidget : global::System.IEquatable<GetDashboard_Dashboard_Widgets_DashboardWidget>, IGetDashboard_Dashboard_Widgets_DashboardWidget
    {
        public GetDashboard_Dashboard_Widgets_DashboardWidget(global::industry9.Client.Data.GraphQL.Generated.IGetDashboard_Dashboard_Widgets_Widget? widget, global::System.String size, global::System.String position)
        {
            Widget = widget;
            Size = size;
            Position = position;
        }

        public global::industry9.Client.Data.GraphQL.Generated.IGetDashboard_Dashboard_Widgets_Widget? Widget { get; }

        public global::System.String Size { get; }

        public global::System.String Position { get; }

        public virtual global::System.Boolean Equals(GetDashboard_Dashboard_Widgets_DashboardWidget? other)
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

            return (((Widget is null && other.Widget is null) || Widget != null && Widget.Equals(other.Widget))) && Size.Equals(other.Size) && Position.Equals(other.Position);
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

            return Equals((GetDashboard_Dashboard_Widgets_DashboardWidget)obj);
        }

        public override global::System.Int32 GetHashCode()
        {
            unchecked
            {
                int hash = 5;
                if (Widget != null)
                {
                    hash ^= 397 * Widget.GetHashCode();
                }

                hash ^= 397 * Size.GetHashCode();
                hash ^= 397 * Position.GetHashCode();
                return hash;
            }
        }
    }
}
