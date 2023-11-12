using AWC.SharedKernel.Base;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class EmploymentStatus : ValueObject
    {
        public bool Value { get; }

        private EmploymentStatus(bool value) => Value = value;

        public static implicit operator bool(EmploymentStatus self) => self.Value;

        public static EmploymentStatus Create(bool status)
        {
            return new EmploymentStatus((bool)status);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}