using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class ManagerId : ValueObject
    {
        public int Value { get; }

        private ManagerId(int employeeId)
            => Value = employeeId;

        public static implicit operator int(ManagerId self) => self.Value!;

        public static ManagerId Create(int value)
        {
            CheckValidity(value);
            return new ManagerId(value);
        }

        private static void CheckValidity(int managerId)
        {
            Guard.Against.LessThan(managerId, 0, "Manager Id should not be less than zero.");
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}