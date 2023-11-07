using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;

namespace AWC.Core.Entities.HumanResources.ValueObjects
{
    public sealed class DepartmentStartDate : ValueObject
    {
        public DateOnly Value { get; }

        private DepartmentStartDate(DateOnly startDate)
            => Value = startDate;

        public static implicit operator DateOnly(DepartmentStartDate self) => self.Value!;

        public static DepartmentStartDate Create(DateOnly value)
        {
            CheckValidity(value);
            return new DepartmentStartDate(value);
        }

        private static void CheckValidity(DateOnly departmentStartDate)
        {
            Guard.Against.DefaultDateOnly(departmentStartDate, "StartDate", "The date the employee was assigned to the department is required.");
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}