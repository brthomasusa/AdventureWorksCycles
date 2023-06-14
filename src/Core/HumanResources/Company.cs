#pragma warning disable CS8618

using AWC.Core.HumanResources.ValueObjects;
using AWC.Core.Shared.ValueObjects;
using AWC.SharedKernel.Base;
using AWC.SharedKernel.Utilities;

namespace AWC.Core.HumanResources
{
    public sealed class Company : AggregateRoot<int>
    {
        private readonly List<Department> _departments = new();
        private readonly List<Shift> _shifts = new();

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

        public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();

        public Result AddDepartment(int id, string name, string groupName)
        {
            try
            {
                Department? dupeID = _departments.Find(dept => dept.Id == id);
                if (dupeID is not null)
                    return Result.Failure(new Error("Company.AddDepartment", $"There is already a department with ID {id}."));

                Department? dupeName = _departments.Find(dept => dept.Name == name);
                if (dupeName is not null)
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

        public Result UpdateDepartment(int id, string name, string groupName)
        {
            try
            {
                Department? dupeName = _departments.Find(dept => dept.Name == name);
                if (dupeName is not null && dupeName.Id != id)
                    return Result.Failure(new Error("Company.UpdateDepartment", "Updating this department would result in two departments with the same name."));

                Department? search = _departments.Find(dept => dept.Id == id);
                if (search is null)
                    return Result.Failure(new Error("Company.UpdateDepartment", $"Update failed, could not locate department with ID {id}."));

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

        public Result DeleteDepartment(int id)
        {
            try
            {
                Department? search = _departments.Find(dept => dept.Id == id);

                if (search is null)
                    return Result.Failure(new Error("Company.DeleteDepartment", $"Delete failed, could not locate department with ID {id}."));

                _departments.Remove(search);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("Company.DeleteDepartment", Helpers.GetExceptionMessage(ex)));
            }
        }

        public Result AddShift
        (
            int id,
            string name,
            int startHour,
            int startMinute,
            int endHour,
            int endMinute
        )
        {
            try
            {
                Shift? searchID = _shifts.Find(shift => shift.Id == id);
                if (searchID is not null)
                    return Result.Failure(new Error("Company.AddShift", $"A shift with ID {id} already exists."));

                TimeOnly startTime = new(startHour, startMinute);
                TimeOnly endTime = new(endHour, endMinute);

                Shift? searchHours = _shifts.Find(shift => shift.StartTime == startTime && shift.EndTime == endTime);
                if (searchHours is not null)
                    return Result.Failure(new Error("Company.AddShift", "A shift with these hours already exists."));

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
            int id,
            string name,
            int startHour,
            int startMinute,
            int endHour,
            int endMinute
        )
        {
            try
            {
                Shift? search = _shifts.Find(shift => shift.Id == id);
                if (search is null)
                    return Result.Failure(new Error("Company.UpdateShift", $"Update failed, could not locate shift with ID {id}."));

                Shift? searchName = _shifts.Find(shift => string.Equals(shift.Name, name, StringComparison.OrdinalIgnoreCase));
                if (searchName is not null && searchName.Id != id)
                    return Result.Failure(new Error("Company.UpdateShift", $"Update failed, an existing shift already has this name: {name}."));

                TimeOnly startTime = new(startHour, startMinute);
                TimeOnly endTime = new(endHour, endMinute);

                Shift? searchHours = _shifts.Find(shift => shift.StartTime == startTime && shift.EndTime == endTime);
                if (searchHours is not null && searchHours.Id != id)
                    return Result.Failure(new Error("Company.UpdateShift", "A shift with these hours already exists."));

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

        public Result DeleteShift(int id)
        {
            try
            {
                Shift? search = _shifts.Find(shift => shift.Id == id);

                if (search is null)
                    return Result.Failure(new Error("Company.DeleteShift", $"Delete failed, could not locate shift with ID {id}."));

                _shifts.Remove(search);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("Company.DeleteShift", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}