#pragma warning disable CS8618

using AWC.Core.Enums;
using AWC.Core.Entities.Shared.ValueObjects;
using AWC.Core.Entities.Shared.EntityIDs;

namespace AWC.Core.Entities.Shared
{
    public sealed class Contact : Person
    {
        private Contact
        (
            ContactID contactID,
            PersonType personType,
            NameStyle nameStyle,
            Title title,
            PersonName name,
            Suffix suffix,
            EmailPromotion emailPromotionEnum,
            ContactType contactType
        ) : base(new PersonID(contactID.Value), personType, nameStyle, title, name, suffix, emailPromotionEnum)
        {
            ContactType = contactType;
        }

        public static Contact Create
        (
            ContactID contactID,
            string personType,
            NameStyle nameStyle,
            string title,
            string firstName,
            string? middleName,
            string lastName,
            string? suffix,
            EmailPromotion emailPromotionEnum,
            ContactType contactType
        )
            => new
                (
                    contactID,
                    PersonType.Create(personType),
                    Enum.IsDefined(typeof(NameStyle), nameStyle) ? nameStyle : throw new ArgumentException("Invalid names style"),
                    Title.Create(title),
                    PersonName.Create(lastName, firstName, middleName!),
                    Suffix.Create(suffix!),
                    Enum.IsDefined(typeof(EmailPromotion), emailPromotionEnum) ? emailPromotionEnum : throw new ArgumentException("Invalid email promotion flag"),
                    Enum.IsDefined(typeof(ContactType), contactType) ? contactType : throw new ArgumentException("Invalid contact type.")
                );

        public int BusinessEntityID { get; }

        public ContactType ContactType { get; private set; }

        public void UpdateContactType(ContactType value)
        {
            ContactType = Enum.IsDefined(typeof(ContactType), value) ? value : throw new ArgumentException("Invalid contact type.");
            UpdateModifiedDate();
        }
    }
}