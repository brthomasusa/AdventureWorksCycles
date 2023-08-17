using Ardalis.Specification;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;

namespace AWC.Infrastructure.Persistence.Specifications.HumanResources
{
    public sealed class ValidateShiftExistSpec : Specification<Shift>, ISingleResultSpecification
    {
        public ValidateShiftExistSpec(byte shiftID)
            => Query.Where(shift => shift.ShiftID == shiftID);
    }
}