using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.HumanResources.ValueObjects
{
    public sealed class ManagerId : ValueObject
    {
        public int Value { get; }

        private ManagerId(int employeeId)
        {
            Value = employeeId;
        }

        public static implicit operator int(ManagerId self) => self.Value!;

        public static ManagerId Create(int value)
        {
            CheckValidity(value);
            return new ManagerId(value);
        }

        private static void CheckValidity(int value)
        {
            Guard.Against.LessThan(value, 1, "Manager Id should be greater than zero.");
        }
    }
}