using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Shared.Commands.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Application.Features.HumanResources.Common;

public static class EmployeeDomainObjectBuilder
{
    public static Result<Employee> Build
    (
        int businessEntityID,
        string PersonType,
        NameStyleEnum nameStyle,
        string? title,
        string firstName,
        string? middleName,
        string lastName,
        string? suffix,
        int managerID,
        string jobTitle,
        string phoneNumber,
        PhoneNumberTypeEnum PhoneNumberTypeID,
        string emailAddress,
        int EmailPromotion,
        string nationalIDNumber,
        string loginID,
        string addressLine1,
        string? addressLine2,
        string city,
        int stateProvinceID,
        string postalCode,
        DateTime birthDate,
        string maritalStatus,
        string gender,
        DateTime hireDate,
        bool salaried,
        int vacationHours,
        int sickLeaveHours,
        bool active,
        List<DepartmentHistoryCommand>? departmentHistories,
        List<PayHistoryCommand>? payHistories
    )
    {
        Result<Employee> createEmployee = Employee.Create
        (
            businessEntityID,
            PersonType,
            nameStyle,
            title,
            firstName,
            lastName,
            middleName!,
            suffix,
            managerID,
            nationalIDNumber,
            loginID,
            jobTitle,
            DateOnly.FromDateTime(birthDate),
            maritalStatus,
            gender,
            DateOnly.FromDateTime(hireDate),
            salaried,
            vacationHours,
            sickLeaveHours,
            active
        );

        if (createEmployee.IsFailure)
            return Result<Employee>.Failure<Employee>(new Error("EmployeeDomainObjectBuilder.Build", createEmployee.Error.Message));

        if (payHistories!.Any())
        {
            foreach (PayHistoryCommand pay in payHistories!)
            {
                Result<PayHistory> result = createEmployee.Value.AddPayHistory(
                    pay.BusinessEntityID,
                    pay.RateChangeDate,
                    pay.Rate,
                    (PayFrequencyEnum)pay.PayFrequency
                );

                if (result.IsFailure)
                    return Result<Employee>.Failure<Employee>(GetError(result.Error.Message));
            }
        }

        if (departmentHistories!.Any())
        {
            foreach (DepartmentHistoryCommand department in departmentHistories!)
            {
                Result<DepartmentHistory> result = createEmployee.Value.AddDepartmentHistory
                (
                    department.BusinessEntityID,
                    department.DepartmentID,
                    department.ShiftID,
                    DateOnly.FromDateTime(department.StartDate),
                    department.EndDate
                );

                if (result.IsFailure)
                    return Result<Employee>.Failure<Employee>(GetError(result.Error.Message));
            }
        }

        Result<Address> createAddress = createEmployee.Value.AddAddress
        (
            0,
            createEmployee.Value.Id,
            AddressTypeEnum.Home,
            addressLine1,
            addressLine2,
            city,
            stateProvinceID,
            postalCode
        );
        if (createAddress.IsFailure)
            return Result<Employee>.Failure<Employee>(GetError(createAddress.Error.Message));

        Result<PersonEmailAddress> createEmailAddress = createEmployee.Value.AddEmailAddress
        (
            createEmployee.Value.Id,
            0,
            emailAddress
        );
        if (createEmailAddress.IsFailure)
            return Result<Employee>.Failure<Employee>(GetError(createEmailAddress.Error.Message));

        Result<PersonPhone> createPersonPhone = createEmployee.Value.AddPhoneNumber
        (
            createEmployee.Value.Id,
            PhoneNumberTypeID,
            phoneNumber
        );
        if (createPersonPhone.IsFailure)
            return Result<Employee>.Failure<Employee>(GetError(createPersonPhone.Error.Message));

        return createEmployee;
    }

    private static Error GetError(string errMsg)
        => new Error("EmployeeDomainObjectBuilder.Build", errMsg);

}
