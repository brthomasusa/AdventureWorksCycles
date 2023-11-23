using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Entities.Shared;
using AWC.Core.Entities.Shared.EntityIDs;
using AWC.Core.Enums;
using AWC.Shared.Commands.HumanResources;
using AWC.SharedKernel.Utilities;
using MapsterMapper;

namespace AWC.Application.Features.HumanResources.Common
{
    public static class BuildEmployeeDomainObject
    {
        public static Result<Employee> Build(CreateEmployeeCommand command, IMapper mapper)
        {
            EmployeeGenericCommand genericCommand = mapper.Map<EmployeeGenericCommand>(command);
            return BuildEmployee(genericCommand);
        }

        public static Result<Employee> Build(UpdateEmployeeCommand command, IMapper mapper)
        {
            EmployeeGenericCommand genericCommand = mapper.Map<EmployeeGenericCommand>(command);
            return BuildEmployee(genericCommand);
        }

        private static Result<Employee> BuildEmployee(EmployeeGenericCommand command)
        {
            // Build employee with department history and payhistory
            Result<Employee> aggregateRootResult = BuildAggregateRoot(command);

            if (aggregateRootResult.IsFailure)
                return Result<Employee>.Failure<Employee>(new Error("BuildEmployeeDomainObject.BuildEmployee", aggregateRootResult.Error.Message));

            // This is needed in order to pass Employee by ref
            Employee employee = aggregateRootResult.Value;

            // Add Address, EmailAddress, and PersonPhone to aggregate root
            Result entitiesResult = BuildAggregateEntities(command, ref employee);
            if (entitiesResult.IsFailure)
                return Result<Employee>.Failure<Employee>(new Error("BuildEmployeeDomainObject.BuildEmployee", entitiesResult.Error.Message));

            return employee;
        }

        private static Result<Employee> BuildAggregateRoot(EmployeeGenericCommand command)
        {
            // 1. Create an employee from the GenericEmployeeComand
            Result<Employee> employeeResult = Employee.Create
            (
                new EmployeeID(command.BusinessEntityID),
                "EM",
                (NameStyle)command.NameStyle,
                command.Title,
                command.FirstName!,
                command.LastName!,
                command.MiddleName!,
                command.Suffix,
                new EmployeeID(command.ManagerID),
                command.NationalIDNumber!,
                command.LoginID!,
                command.JobTitle!,
                DateOnly.FromDateTime(command.BirthDate),
                command.MaritalStatus!,
                command.Gender!,
                DateOnly.FromDateTime(command.HireDate),
                command.Salaried,
                command.VacationHours,
                command.SickLeaveHours,
                command.Active
            );

            if (employeeResult.IsFailure)
                return Result<Employee>.Failure<Employee>(new Error("BuildEmployeeDomainObject.BuildAggregateRoot", employeeResult.Error.Message));

            Employee employee = employeeResult.Value;

            // 2. PayHistory from PayHistoryCommand. A CreateEmployeeCommand should only have one PayHistoryCommand
            if (command.PayHistories!.Any())
            {
                Result payHistoryResult = AddPayHistories(ref employee, command.PayHistories!);
                if (payHistoryResult.IsFailure)
                    return Result<Employee>.Failure<Employee>(new Error("EmployeeDomainObjectBuilder.BuildAggregateRoot", payHistoryResult.Error.Message));
            }

            // 3. DepartmentHistory from DepartmentHistoryCommand. A CreateEmployeeCommand should only have one DepartmentHistoryCommand
            if (command.DepartmentHistories!.Any())
            {
                Result departmentHistoryResult = AddDepartmentHistories(ref employee, command.DepartmentHistories!);
                if (departmentHistoryResult.IsFailure)
                    return Result<Employee>.Failure<Employee>(new Error("EmployeeDomainObjectBuilder.BuildAggregateRoot", departmentHistoryResult.Error.Message));
            }

            // At this point we have an employee with department history and pay history
            return employeeResult.Value;
        }

        private static Result BuildAggregateEntities(EmployeeGenericCommand command, ref Employee employee)
        {
            // 4. Create an Address (domain obj) from fields in the CreateEmployeeCommand
            Result addressResult = AddAddress(
                ref employee,
                0,
                command.AddressLine1!,
                command.AddressLine2,
                command.City!,
                command.StateProvinceID,
                command.PostalCode!
            );

            if (addressResult.IsFailure)
                return Result.Failure(new Error("EmployeeDomainObjectBuilder.BuildAggregateEntities", addressResult.Error.Message));

            // 5. Create a PersonEmailAddress (domain obj) from fields in the CreateEmployeeCommand
            Result emailAddressResult = AddEmailAddress(ref employee, 0, command.EmailAddress!);

            if (emailAddressResult.IsFailure)
                return Result.Failure(new Error("EmployeeDomainObjectBuilder.BuildAggregateEntities", emailAddressResult.Error.Message));

            // 6. Create a PersonPhone (domain obj) from fields in the CreateEmployeeCommand
            Result personPhoneResult = AddPersonPhone(ref employee, (PhoneNumberType)command.PhoneNumberTypeID, command.PhoneNumber!);

            if (personPhoneResult.IsFailure)
                return Result.Failure(new Error("EmployeeDomainObjectBuilder.BuildAggregateEntities", personPhoneResult.Error.Message));

            // At this point we have an employee with department history, pay history, address, email address, 
            // and phone number. Return this to CreateEmployeeCommandHandler and UpdateEmployeeCommandHandler.
            return Result.Success();
        }

        private static Result AddDepartmentHistories(ref Employee employee, List<DepartmentHistoryCommand>? departmentHistories)
        {
            foreach (DepartmentHistoryCommand department in departmentHistories!)
            {
                Result<DepartmentHistory> result = employee.AddDepartmentHistory
                (
                    new DepartmentHistoryID(department.BusinessEntityID),
                    new DepartmentID(department.DepartmentID),
                    new ShiftID(department.ShiftID),
                    DateOnly.FromDateTime(department.StartDate),
                    department.EndDate is null ? null : DateOnly.FromDateTime((DateTime)department.EndDate!)
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
                    new PayHistoryID(pay.BusinessEntityID),
                    pay.RateChangeDate,
                    pay.Rate,
                    (PayFrequency)pay.PayFrequency
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
            string line1,
            string? line2,
            string city,
            int stateProvinceID,
            string postalCode
        )
        {
            Result result = employee.AddAddress
            (
                new AddressID(addressID),
                AddressType.Home,
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
            Result result = employee.AddEmailAddress(new PersonEmailAddressID(emailAddressId), emailAddress);

            if (result.IsFailure)
                return Result.Failure(new Error("EmployeeDomainObjectBuilder.AddEmailAddress", result.Error.Message));
            else
                return Result.Success();
        }

        private static Result AddPersonPhone(ref Employee employee, PhoneNumberType phoneNumberType, string phoneNumber)
        {
            Result result = employee.AddPhoneNumber(new PersonPhoneID(employee.Id.Value), phoneNumberType, phoneNumber);

            if (result.IsFailure)
                return Result.Failure(new Error("EmployeeDomainObjectBuilder.AddPersonPhone", result.Error.Message));
            else
                return Result.Success();
        }
    }
}