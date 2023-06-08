using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Shared.ValueObjects
{
    public sealed class OrganizationName : ValueObject
    {
        public string? Value { get; }

        private OrganizationName(string orgName)
            => Value = orgName;

        public static implicit operator string(OrganizationName self) => self.Value!;

        public static OrganizationName Create(string orgName)
        {
            CheckValidity(orgName);
            return new OrganizationName(orgName);
        }

        private static void CheckValidity(string value)
        {
            Guard.Against.NullOrEmpty(value, "OrganizationName", "An organization name is required.");
            Guard.Against.LengthGreaterThan(value, 50, "OrganizationName", "Maximum length of the organization name is 50 characters.");
        }
    }
}