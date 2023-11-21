#pragma warning disable CS8618

using AWC.Core.Entities.Shared.EntityIDs;
using AWC.Core.Entities.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Entities.Shared
{
    public sealed class PersonEmailAddress : Entity<PersonEmailAddressID>
    {
        private PersonEmailAddress
        (
            PersonEmailAddressID emailAddressID,
            Email emailAddress
        )
        {
            Id = emailAddressID;
            EmailAddress = emailAddress;
        }

        internal static Result<PersonEmailAddress> Create(PersonEmailAddressID id, string email)
        {
            try
            {
                PersonEmailAddress emailAddress = new
                (
                    id,
                    Email.Create(email)
                );

                return emailAddress;
            }
            catch (Exception ex)
            {
                return Result<PersonEmailAddress>.Failure<PersonEmailAddress>(new Error("PersonEmailAddress.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        internal Result<PersonEmailAddress> UpdateEmailAddress(string email)
        {
            try
            {
                EmailAddress = Email.Create(email);

                UpdateModifiedDate();

                return this;
            }
            catch (Exception ex)
            {
                return Result<PersonEmailAddress>.Failure<PersonEmailAddress>(new Error("PersonEmailAddress.Update", Helpers.GetExceptionMessage(ex)));
            }
        }

        public PersonEmailAddressID EmailAddressID { get; }

        public Email EmailAddress { get; private set; }

    }
}