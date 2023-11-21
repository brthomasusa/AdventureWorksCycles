using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.HumanResources.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Entities.HumanResources
{
    public sealed class DepartmentHistory : Entity<DepartmentHistoryID>
    {
        private DepartmentHistory
        (
            DepartmentHistoryID id,
            DepartmentID departmentId,
            ShiftID shiftId,
            DepartmentStartDate startDate,
            DepartmentEndDate endDate
        )
        {
            Id = id;
            DepartmentID = departmentId;
            ShiftID = shiftId;
            StartDate = startDate;
            EndDate = endDate;

            CheckValidity();
        }

        internal static Result<DepartmentHistory> Create
        (
            DepartmentHistoryID id,
            DepartmentID departmentId,
            ShiftID shiftId,
            DateOnly startDate,
            DateOnly? endDate
        )
        {
            try
            {
                return new DepartmentHistory
                    (
                        id,
                        departmentId,
                        shiftId,
                        DepartmentStartDate.Create(startDate),
                        DepartmentEndDate.Create(endDate)
                    );

            }
            catch (Exception ex)
            {
                return Result<DepartmentHistory>.Failure<DepartmentHistory>(new Error("DepartmentHistory.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        public DepartmentID DepartmentID { get; }
        public ShiftID ShiftID { get; }
        public DepartmentStartDate StartDate { get; }
        public DepartmentEndDate EndDate { get; private set; }

        protected override void CheckValidity()
        {
            if (EndDate.Value != new DateOnly() && StartDate.Value > EndDate.Value)
                throw new ArgumentException("Start date can not be after end date.");
        }
    }
}