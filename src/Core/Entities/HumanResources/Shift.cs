#pragma warning disable CS8618

using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.HumanResources.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Entities.HumanResources
{
    public sealed class Shift : Entity<ShiftID>
    {
        private Shift
        (
            ShiftID id,
            ShiftName name,
            ShiftTime startTime,
            ShiftTime endTime
        )
        {
            Id = id;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }

        internal static Result<Shift> Create
        (
            ShiftID id,
            string name,
            int startHour,
            int startMinute,
            int endHour,
            int endMinute
        )
        {
            try
            {
                Shift shift = new(
                 id,
                 ShiftName.Create(name),
                 ShiftTime.Create(startHour, startMinute),
                 ShiftTime.Create(endHour, endMinute)
                 );

                return shift;
            }
            catch (Exception ex)
            {
                return Result<Shift>.Failure<Shift>(new Error("Shift.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        internal Result<Shift> Update(string name, int startHour, int startMinute, int endHour, int endMinute)
        {
            try
            {
                Name = ShiftName.Create(name);
                StartTime = ShiftTime.Create(startHour, startMinute);
                EndTime = ShiftTime.Create(endHour, endMinute);
                UpdateModifiedDate();

                return this;
            }
            catch (Exception ex)
            {
                return Result<Shift>.Failure<Shift>(new Error("Shift.Update", Helpers.GetExceptionMessage(ex)));
            }
        }

        public ShiftName Name { get; private set; }

        public ShiftTime StartTime { get; private set; }

        public ShiftTime EndTime { get; private set; }
    }
}