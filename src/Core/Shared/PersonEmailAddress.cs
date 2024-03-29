#pragma warning disable CS8618

using AWC.Core.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Shared
{
    public sealed class PersonEmailAddress : Entity<int>
    {
        private PersonEmailAddress
        (
            int id,
            int emailAddressID,
            EmailAddressVO emailAddress
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
                    Guard.Against.LessThanZero(id, "BusinessEntityID", "BusinessEntity Id can not be negative."),
                    Guard.Against.LessThanZero(emailAddressID, "EmailAddressID", "Email address Id can not be negative."),
                    EmailAddressVO.Create(email)
                );

                return emailAddress;
            }
            catch (Exception ex)
            {
                return Result<PersonEmailAddress>.Failure<PersonEmailAddress>(new Error("PersonEmailAddress.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        public int EmailAddressID { get; }

        public EmailAddressVO EmailAddress { get; private set; }

        public void UpdateEmailAddress(string email)
        {
            EmailAddress = EmailAddressVO.Create(email);
            UpdateModifiedDate();
        }
    }
}