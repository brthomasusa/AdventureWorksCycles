#pragma warning disable CS8618

using AWC.Core.Entities.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Entities.Shared
{
    public sealed class PersonEmailAddress : Entity<int>
    {
        private PersonEmailAddress
        (
            int id,
            int emailAddressID,
            Email emailAddress
        )
        {
            Id = id;
            EmailAddressID = emailAddressID;
            EmailAddress = emailAddress;
        }

        internal static Result<PersonEmailAddress> Create(int id, int emailAddressID, string email)
        {
            try
            {
                PersonEmailAddress emailAddress = new
                (
                    Guard.Against.LessThan(id, 0, "BusinessEntity Id can not be negative."),
                    Guard.Against.LessThan(emailAddressID, 0, "Email address Id can not be negative."),
                    Email.Create(email)
                );

                return emailAddress;
            }
            catch (Exception ex)
            {
                return Result<PersonEmailAddress>.Failure<PersonEmailAddress>(new Error("PersonEmailAddress.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        public int EmailAddressID { get; }

        public Email EmailAddress { get; private set; }

        public void UpdateEmailAddress(string email)
        {
            EmailAddress = Email.Create(email);
            UpdateModifiedDate();
        }
    }
}