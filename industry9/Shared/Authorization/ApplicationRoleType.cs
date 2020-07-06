namespace industry9.Shared.Authorization
{
    public enum ApplicationRoleType
    {
        User,
        Administrator
    }

    public static class ApplicationRoleExtensions
    {
        public static string ToName(this ApplicationRoleType roleType)
        {
            return roleType.ToString();
        }

        public static string ToClaim(this ApplicationRoleType roleType)
        {
            return $"Is{roleType}";
        }
    }
}
