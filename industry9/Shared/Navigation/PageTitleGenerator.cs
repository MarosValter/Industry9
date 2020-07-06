using System;
using System.Globalization;

namespace industry9.Shared.Navigation
{
    public class PageTitleGenerator
    {
        private const string Domain = "industry9";

        public static PageTitle Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));
            }

            var textInfo = CultureInfo.CurrentCulture.TextInfo;

            title = title.Replace('-', ' ');
            title = textInfo.ToTitleCase(title);

            var pageTitle = title switch
            {
                "/" => Domain,
                _ => $"{title} | {Domain}"
            };

            var pageName = title switch
            {
                "/" => "Select dashboard",
                _ => title
            };

            return new PageTitle
            {
                Title = pageTitle,
                Name = pageName
            };
		}
    }
}
