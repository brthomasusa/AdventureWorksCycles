using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class DepartmentEndDate : ValueObject
    {
        public DateOnly? Value { get; }

        private DepartmentEndDate(DateOnly? startDate)
            => Value = startDate;

        public static DepartmentEndDate Create(DateOnly? value)
        {
            CheckValidity(value);
            return new DepartmentEndDate(value);
        }

        private static void CheckValidity(DateOnly? departmentEndDate)
        {
            if (departmentEndDate is not null)
                Guard.Against.DefaultDateOnly((DateOnly)departmentEndDate, "EndDate", "The date the employee was assigned to another department is required.");
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value!;
        }
    }
}