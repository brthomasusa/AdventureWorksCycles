#pragma warning disable CS8618

using AWC.Core.Shared.ValueObjects;
using AWC.SharedKernel.Base;

namespace AWC.Core.Shared
{
    public sealed class Contact : Person
    {
        private Contact
        (
            int businessEntityID,
            ContactTypeEnum contactType,
            int personID,
            PersonType personType,
            NameStyleEnum nameStyle,
            Title title,
            PersonName name,
            Suffix suffix,
            EmailPromotionEnum emailPromotionEnum
        ) : base(personID, personType, nameStyle, title, name, suffix, emailPromotionEnum)
        {
            BusinessEntityID = businessEntityID;
            ContactType = contactType;
        }

        public static Contact Create
        (
            int businessEntityID,
            ContactTypeEnum contactType,
            int personID,
            string personType,
            NameStyleEnum nameStyle,
            string title,
            string firstName,
            string? middleName,
            string lastName,
            string? suffix,
            EmailPromotionEnum emailPromotionEnum
        )
            => new
                (
                    businessEntityID,
                    Enum.IsDefined(typeof(ContactTypeEnum), contactType) ? contactType : throw new ArgumentException("Invalid contact type."),
                    personID,
                    PersonType.Create(personType),
                    Enum.IsDefined(typeof(NameStyleEnum), nameStyle) ? nameStyle : throw new ArgumentException("Invalid names style"),
                    Title.Create(title),
                    PersonName.Create(lastName, firstName, middleName!),
                    Suffix.Create(suffix!),
                    Enum.IsDefined(typeof(EmailPromotionEnum), emailPromotionEnum) ? emailPromotionEnum : throw new ArgumentException("Invalid email promotion flag")
                );

        public int BusinessEntityID { get; }

        public ContactTypeEnum ContactType { get; private set; }

        public void UpdateContactType(ContactTypeEnum value)
        {
            ContactType = Enum.IsDefined(typeof(ContactTypeEnum), value) ? value : throw new ArgumentException("Invalid contact type.");
            UpdateModifiedDate();
        }
    }

    public enum ContactTypeEnum : int
    {
        AccountingManager = 1,
        AssistantSalesAgent = 2,
        AssistantSalesRepresentative = 3,
        CoordinatorForeignMarkets = 4,
        ExportAdministrator = 5,
        InternationalMarketingManager = 6,
        MarketingAssistant = 7,
        MarketingManager = 8,
        MarketingRepresentative = 9,
        OrderAdministrator = 10,
        Owner = 11,
        OwnerMarketingAssistant = 12,
        ProductManager = 13,
        PurchasingAgent = 14,
        PurchasingManager = 15,
        RegionalAccountRepresentative = 16,
        SalesAgent = 17,
        SalesAssociate = 18,
        SalesManager = 19,
        SalesRepresentative = 20
    }
}