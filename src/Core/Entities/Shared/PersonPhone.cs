#pragma warning disable CS8618

using AWC.Core.Entities.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Entities.Shared
{
    public sealed class PersonPhone : Entity<int>
    {
        private PersonPhone
        (
            int id,
            PhoneNumberType phoneType,
            PhoneNumber phoneNumber
        )
        {
            Id = id;
            PhoneNumberType = phoneType;
            Telephone = phoneNumber;
        }

        internal static Result<PersonPhone> Create
        (
            int id,
            PhoneNumberType phoneNumberType,
            string telephone
        )
        {
            try
            {
                PersonPhone phone = new
                (
                    id,
                    Enum.IsDefined(typeof(PhoneNumberType), phoneNumberType) ? phoneNumberType : throw new ArgumentException("Invalid phone number type."),
                    PhoneNumber.Create(telephone)
                );

                return phone;
            }
            catch (Exception ex)
            {
                return Result<PersonPhone>.Failure<PersonPhone>(new Error("PersonPhone.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        public PhoneNumberType PhoneNumberType { get; }

        public PhoneNumber Telephone { get; }
    }

    public enum PhoneNumberType
    {
        Cell = 1,
        Home = 2,
        Work = 3
    }
}