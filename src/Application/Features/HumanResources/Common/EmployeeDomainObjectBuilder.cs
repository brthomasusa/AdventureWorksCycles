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
        PhoneNumberTypeEnum phoneNumberTypeID,
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
        // 1. Create an employee from the CreateEmployeeComand
        Result<Employee> employeeResult = Employee.Create
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

        if (employeeResult.IsFailure)
            return Result<Employee>.Failure<Employee>(new Error("EmployeeDomainObjectBuilder.Build", employeeResult.Error.Message));

        // This is needed in order to pass Employee by ref
        Employee employee = employeeResult.Value;

        // 2. PayHistory from PayHistoryCommand. A CreateEmployeeCommand should only have one PayHistoryCommand
        if (payHistories!.Any())
        {
            Result payHistoryResult = AddPayHistories(ref employee, payHistories!);
            if (payHistoryResult.IsFailure)
                return Result<Employee>.Failure<Employee>(GetError(payHistoryResult.Error.Message));
        }

        // 3. DepartmentHistory from DepartmentHistoryCommand. A CreateEmployeeCommand should only have one DepartmentHistoryCommand
        if (departmentHistories!.Any())
        {
            Result departmentHistoryResult = AddDepartmentHistories(ref employee, departmentHistories!);
            if (departmentHistoryResult.IsFailure)
                return Result<Employee>.Failure<Employee>(GetError(departmentHistoryResult.Error.Message));
        }

        // 4. Create an Address (domain obj) from fields in the CreateEmployeeCommand
        Result addressResult = AddAddress(
            ref employee,
            0,
            businessEntityID,
            AddressTypeEnum.Home,
            addressLine1,
            addressLine2,
            city,
            stateProvinceID,
            postalCode
        );

        if (addressResult.IsFailure)
            return Result<Employee>.Failure<Employee>(GetError(addressResult.Error.Message));

        // 5. Create a PersonEmailAddress (domain obj) from fields in the CreateEmployeeCommand
        Result emailAddressResult = AddEmailAddress(ref employee, 0, emailAddress);

        if (emailAddressResult.IsFailure)
            return Result<Employee>.Failure<Employee>(GetError(emailAddressResult.Error.Message));

        // 6. Create a PersonPhone (domain obj) from fields in the CreateEmployeeCommand
        Result personPhoneResult = AddPersonPhone(ref employee, phoneNumberTypeID, phoneNumber);

        if (personPhoneResult.IsFailure)
            return Result<Employee>.Failure<Employee>(GetError(personPhoneResult.Error.Message));

        // At this point we have an employee with department history, pay history, address, email address, 
        // and phone number. Return this to CreateEmployeeCommandHandler and UpdateEmployeeCommandHandler.
        return employeeResult;
    }

    private static Result AddDepartmentHistories(ref Employee employee, List<DepartmentHistoryCommand>? departmentHistories)
    {
        foreach (DepartmentHistoryCommand department in departmentHistories!)
        {
            Result<DepartmentHistory> result = employee.AddDepartmentHistory
            (
                department.BusinessEntityID,
                department.DepartmentID,
                department.ShiftID,
                DateOnly.FromDateTime(department.StartDate),
                department.EndDate
            );

            if (result.IsFailure)
                return Result.Failure(new Error("EmployeeDomainObjectBuilder.AddDepartmentHistories", result.Error.Message));
        }
        return Result.Success();
    }

    private static Result AddPayHistories(ref Employee employee, List<PayHistoryCommand>? payHistories)
    {
        foreach (PayHistoryCommand pay in payHistories!)
        {
            Result result = employee.AddPayHistory(
                pay.BusinessEntityID,
                pay.RateChangeDate,
                pay.Rate,
                (PayFrequencyEnum)pay.PayFrequency
            );

            if (result.IsFailure)
                return Result.Failure(new Error("EmployeeDomainObjectBuilder.AddPayHistories", result.Error.Message));
        }
        return Result.Success();
    }

    private static Result AddAddress
    (
        ref Employee employee,
        int addressID,
        int businessEntityID,
        AddressTypeEnum addressType,
        string line1,
        string? line2,
        string city,
        int stateProvinceID,
        string postalCode
    )
    {
        Result result = employee.AddAddress
        (
            0,
            employee.Id,
            AddressTypeEnum.Home,
            line1,
            line2,
            city,
            stateProvinceID,
            postalCode
        );

        if (result.IsFailure)
            return Result.Failure(new Error("EmployeeDomainObjectBuilder.AddAddress", result.Error.Message));
        else
            return Result.Success();
    }

    private static Result AddEmailAddress(ref Employee employee, int emailAddressId, string emailAddress)
    {
        Result result = employee.AddEmailAddress(employee.Id, emailAddressId, emailAddress);

        if (result.IsFailure)
            return Result.Failure(new Error("EmployeeDomainObjectBuilder.AddEmailAddress", result.Error.Message));
        else
            return Result.Success();
    }

    private static Result AddPersonPhone(ref Employee employee, PhoneNumberTypeEnum phoneNumberType, string phoneNumber)
    {
        Result result = employee.AddPhoneNumber(employee.Id, phoneNumberType, phoneNumber);

        if (result.IsFailure)
            return Result.Failure(new Error("EmployeeDomainObjectBuilder.AddPersonPhone", result.Error.Message));
        else
            return Result.Success();
    }

    private static Error GetError(string errMsg)
        => new Error("EmployeeDomainObjectBuilder.Build", errMsg);

}
