#pragma warning disable CS8618

using AWC.SharedKernel.Base;

namespace AWC.Core.HumanResources.ValueObjects
{
    public sealed class JobTitle : ValueObject
    {
        public string Value { get; }

        private JobTitle(string value)
            => Value = value;

        public static implicit operator string(JobTitle self) => self.Value;

        public static JobTitle Create(string value)
        {
            CheckValidity(value);
            return new JobTitle(value);
        }

        private static void CheckValidity(string jobTitle)
        {
            if (string.IsNullOrEmpty(jobTitle))
            {
                throw new ArgumentNullException(nameof(jobTitle), "The job title is required.");
            }

            if (jobTitle.Length > 50)
            {
                throw new ArgumentException("Invalid job title, maximum length is 50 characters.");
            }
        }
    }
}