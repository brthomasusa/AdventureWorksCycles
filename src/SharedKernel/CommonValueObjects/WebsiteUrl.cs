#pragma warning disable CS8618

using System.Text.RegularExpressions;
using AWC.SharedKernel.Base;

namespace AWC.SharedKernel.CommonValueObjects
{
    public partial class WebsiteUrl : ValueObject
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
            Regex Rgx = UrlRegex();

            if (!Rgx.IsMatch(value))
            {
                throw new ArgumentException("Invalid website URL!", nameof(value));
            }
        }

        [GeneratedRegex("^(?:http(s)?:\\/\\/)?[\\w.-]+(?:\\.[\\w\\.-]+)+[\\w\\-\\._~:/?#[\\]@!\\$&'\\(\\)\\*\\+,;=.]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
        private static partial Regex UrlRegex();
    }
}