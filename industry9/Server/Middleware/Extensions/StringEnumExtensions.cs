using System;
using System.ComponentModel;
using System.Globalization;

namespace industry9.Server.Middleware.Extensions
{
    public static class StringEnumExtensions
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (!(e is Enum))
            {
                return null;
            }

            var type = e.GetType();
            var values = Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val == e.ToInt32(CultureInfo.InvariantCulture))
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (descriptionAttributes.Length > 0)
                    {
                        return ((DescriptionAttribute)descriptionAttributes[0]).Description;
                    }
                }
            }

            return null;
        }
    }
}
