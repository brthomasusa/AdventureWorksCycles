#pragma warning disable CS8618

using AWC.Core.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Guards;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Shared
{
    public sealed class Address : Entity<int>
    {
        private Address
        (
            int addressID,
            int businessEntityID,
            AddressType addressType,
            AddressVO address
        )
        {
            Id = addressID;
            BusinessEntityID = businessEntityID;
            AddressType = addressType;
            Location = address;
        }

        internal static Result<Address> Create
        (
            int addressID,
            int businessEntityID,
            AddressType addressType,
            string line1,
            string? line2,
            string city,
            int stateProvinceID,
            string postalCode
        )
        {
            try
            {
                Address address = new
                (
                    Guard.Against.LessThanZero(addressID, "Id", "Address Id can not be negative."),
                    Guard.Against.LessThanZero(businessEntityID, "Id", "BusinessEntity Id can not be negative."),
                    Enum.IsDefined(typeof(AddressType), addressType) ? addressType : throw new ArgumentException("Invalid address type."),
                    AddressVO.Create(line1, line2, city, stateProvinceID, postalCode)
                );

                return address;
            }
            catch (Exception ex)
            {
                return Result<Address>.Failure<Address>(new Error("Address.Create", Helpers.GetExceptionMessage(ex)));
            }
        }

        internal Result<Address> Update
        (
            AddressType addressType,
            string line1,
            string? line2,
            string city,
            int stateProvinceID,
            string postalCode
        )
        {
            try
            {
                AddressType = Enum.IsDefined(typeof(AddressType), addressType) ? addressType : throw new ArgumentException("Invalid address type.");
                Location = AddressVO.Create(line1, line2, city, stateProvinceID, postalCode);

                UpdateModifiedDate();

                return this;
            }
            catch (Exception ex)
            {
                return Result<Address>.Failure<Address>(new Error("Address.Update", Helpers.GetExceptionMessage(ex)));
            }
        }

        public int BusinessEntityID { get; }
        public AddressType AddressType { get; private set; }
        public AddressVO Location { get; private set; }
    }

    public enum AddressType
    {
        Billing = 1,
        Home = 2,
        MainOffice = 3,
        Primary = 4,
        Shipping = 5,
        Archive = 6
    }
}