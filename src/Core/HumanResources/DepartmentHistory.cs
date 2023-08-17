using AWC.Core.HumanResources.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.HumanResources
{
    public sealed class DepartmentHistory : Entity<int>
    {
        private DepartmentHistory
        (
            int id,
            int departmentId,
            int shiftId,
            DepartmentStartDate startDate,
            DateOnly? endDate
        )
        {
            Id = id;
            DepartmentID = departmentId;
            ShiftID = shiftId;
            StartDate = startDate.Value;
            EndDate = endDate;

            CheckValidity();
        }

        internal static Result<DepartmentHistory> Create
        (
            int id,
            int departmentId,
            int shiftId,
            DateOnly startDate,
            DateTime? endDate
        )
        {
            try
            {
                return new DepartmentHistory
                    (
                        Guard.Against.LessThanZero(id, nameof(Id), "Employee id can not be negative."),
                        Guard.Against.GreaterThan(departmentId, 0, nameof(DepartmentID), "Department id is required."),
                        Guard.Against.GreaterThan(shiftId, 0, nameof(shiftId), "Shift id is required."),
                        DepartmentStartDate.Create(startDate),
                        DateOnly.FromDateTime(endDate is null ? default : (DateTime)endDate)
                    );

            }
            catch (Exception ex)
            {
                return Result<DepartmentHistory>.Failure<DepartmentHistory>(new Error("DepartmentHistory.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        public int DepartmentID { get; }
        public int ShiftID { get; }
        public DateOnly StartDate { get; }
        public DateOnly? EndDate { get; private set; }

        protected override void CheckValidity()
        {
            if (EndDate != new DateOnly() && StartDate > EndDate)
                throw new ArgumentException("Start date can not be after end date.");
        }
    }
}