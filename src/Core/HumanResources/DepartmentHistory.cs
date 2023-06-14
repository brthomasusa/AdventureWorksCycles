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
            int shiftId,
            DepartmentStartDate startDate,
            DateOnly? endDate
        )
        {
            Id = id;
            ShiftID = shiftId;
            StartDate = startDate.Value;
            EndDate = endDate;

            CheckValidity();
        }

        internal static Result<DepartmentHistory> Create
        (
            int id,
            int shiftId,
            DateOnly startDate,
            DateTime? endDate
        )
        {
            try
            {
                DepartmentHistory history = new
                    (
                        Guard.Against.LessThanZero(id, "Id", "DepartmentHistory id can not be negative."),
                        Guard.Against.LessThanZero(shiftId, nameof(shiftId), "Shift id can not be negative."),
                        DepartmentStartDate.Create(startDate),
                        DateOnly.FromDateTime(endDate is null ? default : (DateTime)endDate)
                    );
                return history;
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