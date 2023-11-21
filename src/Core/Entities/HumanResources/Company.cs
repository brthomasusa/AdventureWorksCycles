using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.HumanResources.ValueObjects;
using AWC.Core.Entities.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.Entities.HumanResources
{
    public sealed class Company : AggregateRoot<CompanyID>
    {
        private readonly List<Department> _departments = new();
        private readonly List<Shift> _shifts = new();

        private Company
        (
            CompanyID companyId,
            OrganizationName companyName,
            OrganizationName legalName,
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
            string? legalName,
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
                    new CompanyID(companyId),
                    OrganizationName.Create(companyName ?? throw new ArgumentNullException(nameof(companyName))),
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
                ArgumentNullException.ThrowIfNull(companyName);

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
        public OrganizationName LegalName { get; private set; }
        public EmployerIdentificationNumber EIN { get; private set; }
        public WebsiteUrl CompanyWebSite { get; private set; }
        public AddressVO PostalAddress { get; private set; }
        public AddressVO DeliveryAddress { get; private set; }
        public PhoneNumber Telephone { get; private set; }
        public PhoneNumber Fax { get; private set; }

        public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();

        public Result AddDepartment(DepartmentID id, string name, string groupName)
        {
            try
            {
                if (_departments.Exists(dept => dept.Id.Value == id.Value && id.Value != 0))
                    return Result.Failure(new Error("Company.AddDepartment", $"There is already a department with ID {id}."));

                if (_departments.Exists(dept => string.Equals(dept.Name, name, StringComparison.OrdinalIgnoreCase)))
                    return Result.Failure(new Error("Company.AddDepartment", $"There is already a department with department name {name}."));

                Result<Department> result = Department.Create(id, name, groupName);

                if (result.IsSuccess)
                {
                    _departments.Add(result.Value);
                    return result;
                }

                return Result.Failure(new Error("Company.AddDepartment", result.Error.Message));
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("Company.AddDepartment", Helpers.GetExceptionMessage(ex)));
            }
        }

        public Result UpdateDepartment(DepartmentID id, string name, string groupName)
        {
            try
            {
                Department? search = _departments.Find(dept => dept.Id.Value == id.Value);

                if (search is null)
                    return Result.Failure(new Error("Company.UpdateDepartment", $"Update failed, could not locate department with ID {id}."));

                if (_departments.Exists(dept => string.Equals(dept.Name, name, StringComparison.OrdinalIgnoreCase) && dept.Id.Value != id.Value))
                    return Result.Failure(new Error("Company.UpdateDepartment", "Updating this department would result in two departments with the same name."));

                Result<Department> result = search.Update(name, groupName);

                if (result.IsSuccess)
                    return Result.Success();

                return Result.Failure(new Error("Company.UpdateDepartment", result.Error.Message));
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("Company.UpdateDepartment", Helpers.GetExceptionMessage(ex)));
            }
        }

        public Result DeleteDepartment(DepartmentID id)
        {
            try
            {
                Department? search = _departments.Find(dept => dept.Id.Value == id.Value);

                if (search is null)
                    return Result.Failure(new Error("Company.DeleteDepartment", $"Delete failed, could not locate department with ID {id}."));

                search.EntityStatus = EntityStatus.Deleted;
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("Company.DeleteDepartment", Helpers.GetExceptionMessage(ex)));
            }
        }

        public IReadOnlyCollection<Shift> Shifts => _shifts.AsReadOnly();

        public Result AddShift
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
                if (_shifts.Exists(shift => shift.Id.Value == id.Value && id.Value != 0))
                    return Result.Failure(new Error("Company.AddShift", $"A shift with ID {id} already exists."));

                if (_shifts.Exists(shift => string.Equals(shift.Name, name, StringComparison.OrdinalIgnoreCase)))
                    return Result.Failure(new Error("Company.AddShift", $"A shift with name {name} already exists."));

                ShiftTime startTime = ShiftTime.Create(startHour, startMinute);
                ShiftTime endTime = ShiftTime.Create(endHour, endMinute);

                if (_shifts.Exists(shift => shift.StartTime.Equals(startTime) && shift.EndTime.Equals(endTime)))
                    return Result.Failure(new Error("Company.AddShift", "A shift with the same start and end time already exists."));

                Result<Shift> result = Shift.Create(id, name, startHour, startMinute, endHour, endMinute);

                if (result.IsFailure)
                    return Result.Failure(new Error("Company.AddShift", result.Error.Message));

                _shifts.Add(result.Value);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("Company.AddShift", Helpers.GetExceptionMessage(ex)));
            }
        }

        public Result UpdateShift
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
                Shift? search = _shifts.Find(shift => shift.Id.Value == id.Value);
                if (search is null)
                    return Result.Failure(new Error("Company.UpdateShift", $"Update failed, could not locate shift with ID {id}."));

                if (_shifts.Exists(shift => string.Equals(shift.Name, name, StringComparison.OrdinalIgnoreCase) && shift.Id.Value != id.Value))
                    return Result.Failure(new Error("Company.AddShift", $"A shift with name {name} already exists."));

                ShiftTime startTime = ShiftTime.Create(startHour, startMinute);
                ShiftTime endTime = ShiftTime.Create(endHour, endMinute);

                if (_shifts.Exists(shift => shift.StartTime.Equals(startTime) && shift.EndTime.Equals(endTime) && shift.Id.Value != id.Value))
                    return Result.Failure(new Error("Company.AddShift", "A shift with the same start and end time already exists."));

                Result<Shift> result = search.Update(name, startHour, startMinute, endHour, endMinute);

                if (result.IsFailure)
                    return Result.Failure(new Error("Company.UpdateShift", result.Error.Message));

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("Company.UpdateShift", Helpers.GetExceptionMessage(ex)));
            }
        }

        public Result DeleteShift(ShiftID id)
        {
            try
            {
                Shift? search = _shifts.Find(shift => shift.Id.Value == id.Value);

                if (search is null)
                    return Result.Failure(new Error("Company.DeleteShift", $"Delete failed, could not locate shift with ID {id}."));

                search.EntityStatus = EntityStatus.Deleted;
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("Company.DeleteShift", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}