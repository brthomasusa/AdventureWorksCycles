#pragma warning disable CS8618

using System.Text.RegularExpressions;
using AWC.SharedKernel.Base;

namespace AWC.SharedKernel.CommonValueObjects
{
    public class WebsiteUrl : ValueObject
    {
        public string Value { get; }

        protected WebsiteUrl() { }

        private WebsiteUrl(string value) : this() => Value = value;

        public static implicit operator string(WebsiteUrl self) => self.Value!;

        public static WebsiteUrl Create(string url)
        {
            CheckValidity(url);
            return new WebsiteUrl(url);
        }

        private static void CheckValidity(string value)
        {
            const string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            if (!Rgx.IsMatch(value))
            {
                throw new ArgumentException("Invalid website URL!", nameof(value));
            }
        }
    }
}