using AWC.SharedKernel.Base;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class EmploymentStatus : ValueObject
    {
        public bool Value { get; }

        private EmploymentStatus(bool value) => Value = value;

        public static implicit operator bool(EmploymentStatus self) => self.Value;

        public static EmploymentStatus Create(bool? status)
        {
            if (status is not null)
                return new EmploymentStatus((bool)status);
            else
                throw new ArgumentException("Employment status is required.", nameof(status));
        }
    }
}