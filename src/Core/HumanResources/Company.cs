#pragma warning disable CS8618

using AWC.Core.HumanResources.ValueObjects;
using AWC.Core.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.HumanResources
{
    public sealed class Company : AggregateRoot<int>
    {
        private Company
        (
            int companyId,
            OrganizationName companyName,
            OrganizationName? legalName,
            EmployerIdentificationNumber ein,
            WebsiteUrl companyWebSite,
            AddressVO postalAddress,
            AddressVO deliveryAddress,
            PhoneNumber telephone,
            PhoneNumber fax
        )
        {
            Id = companyId;
            CompanyName = companyName;
            LegalName = legalName!;
            EIN = ein;
            CompanyWebSite = companyWebSite!;
            PostalAddress = postalAddress;
            DeliveryAddress = deliveryAddress;
            Telephone = telephone;
            Fax = fax;
        }

        public static Result<Company> Create
        (
            int companyId,
            string companyName,
            string legalName,
            string ein,
            string companyWebSite,
            string mailLine1,
            string? mailLine2,
            string mailCity,
            int mailStateProvinceID,
            string mailPostalCode,
            string deliveryLine1,
            string? deliveryLine2,
            string deliveryCity,
            int deliveryStateProvinceID,
            string deliveryPostalCode,
            string telephone,
            string fax
        )
        {
            try
            {
                Company company = new
                (
                    companyId,
                    OrganizationName.Create(companyName),
                    OrganizationName.Create(legalName!),
                    EmployerIdentificationNumber.Create(ein),
                    WebsiteUrl.Create(companyWebSite!),
                    AddressVO.Create(mailLine1, mailLine2, mailCity, mailStateProvinceID, mailPostalCode),
                    AddressVO.Create(deliveryLine1, deliveryLine2, deliveryCity, deliveryStateProvinceID, deliveryPostalCode),
                    PhoneNumber.Create(telephone),
                    PhoneNumber.Create(fax)
                );

                return company;
            }
            catch (Exception ex)
            {
                return Result<Company>.Failure<Company>(new Error("Company.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        public Result<Company> Update
        (
            string companyName,
            string legalName,
            string ein,
            string companyWebSite,
            string mailLine1,
            string? mailLine2,
            string mailCity,
            int mailStateProvinceID,
            string mailPostalCode,
            string deliveryLine1,
            string? deliveryLine2,
            string deliveryCity,
            int deliveryStateProvinceID,
            string deliveryPostalCode,
            string telephone,
            string fax
        )
        {
            try
            {
                CompanyName = OrganizationName.Create(companyName);
                LegalName = OrganizationName.Create(legalName);
                EIN = EmployerIdentificationNumber.Create(ein);
                CompanyWebSite = WebsiteUrl.Create(companyWebSite);
                PostalAddress = AddressVO.Create(mailLine1, mailLine2, mailCity, mailStateProvinceID, mailPostalCode);
                DeliveryAddress = AddressVO.Create(deliveryLine1, deliveryLine2, deliveryCity, deliveryStateProvinceID, deliveryPostalCode);
                Telephone = PhoneNumber.Create(telephone);
                Fax = PhoneNumber.Create(fax);

                return this;
            }
            catch (Exception ex)
            {
                return Result<Company>.Failure<Company>(new Error("Company.Update", Helpers.GetExceptionMessage(ex)));
            }
        }

        public OrganizationName CompanyName { get; private set; }
        public OrganizationName? LegalName { get; private set; }
        public EmployerIdentificationNumber EIN { get; private set; }
        public WebsiteUrl? CompanyWebSite { get; private set; }
        public AddressVO PostalAddress { get; private set; }
        public AddressVO DeliveryAddress { get; private set; }
        public PhoneNumber Telephone { get; private set; }
        public PhoneNumber Fax { get; private set; }
    }
}