using Ardalis.Specification.EntityFrameworkCore;
using AWC.Core.Interfaces;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.Specifications.HumanResources;
using AWC.SharedKernel.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class EmployeeValidationRepository : IEmployeeValidationRepository
    {
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;

        public EmployeeValidationRepository(AwcContext ctx, ILogger<WriteRepositoryManager> logger)
        {
            _context = ctx;
            _logger = logger;
        }

        public async Task<Result> ValidatePersonNameIsUnique(int id, string fname, string lname, string? middleName, bool asNoTracking = true)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var person = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<PersonDataModel>().AsNoTracking(),
                        new ValidateEmployeeNameIsUniqueSpec(fname, lname, middleName)
                    )
                    .Select(p => new { p.BusinessEntityID })
                    .FirstOrDefaultAsync(cancellationToken);

                if (person is null || person.BusinessEntityID == id)
                    return Result.Success();

                return Result.Failure
                (
                    new Error
                    (
                        "EmployeeValidationRepository.ValidatePersonNameIsUnique",
                        $"A person named ${fname} {middleName} {lname} is already in the database."
                    )
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeValidationRepository.ValidatePersonNameIsUnique - {Helpers.GetExceptionMessage(ex)}");

                return Result.Failure
                (
                    new Error
                    (
                        "EmployeeValidationRepository.ValidatePersonNameIsUnique",
                        Helpers.GetExceptionMessage(ex)
                    )
                );
            }
        }

        public async Task<Result> ValidateNationalIdNumberIsUnique(int id, string nationalIdNumber, bool asNoTracking = true)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var employee = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<EmployeeDataModel>().AsNoTracking(),
                        new ValidateNationalIdNumberIsUniqueSpec(nationalIdNumber)
                    )
                    .Select(s => new { s.BusinessEntityID })
                    .FirstOrDefaultAsync(cancellationToken);

                if (employee is null || employee.BusinessEntityID == id)
                    return Result.Success();

                return Result.Failure(new Error("EmployeeValidationRepository.ValidateNationalIdNumberIsUnique", $"An employee with natioanal ID {nationalIdNumber} is already in the database."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeValidationRepository.ValidateNationalIdNumberIsUnique - {Helpers.GetExceptionMessage(ex)}");
                return Result.Failure(new Error("EmployeeValidationRepository.ValidateNationalIdNumberIsUnique.", Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result> ValidateEmployeeEmailIsUnique(int id, string emailAddres, bool asNoTracking = true)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var email = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<PersonDataModel>().AsNoTracking(),
                        new ValidateEmployeeEmailIsUniqueSpec(emailAddres)
                    )
                    .Select(s => new { s.BusinessEntityID })
                    .FirstOrDefaultAsync(cancellationToken);

                if (email is null || email.BusinessEntityID == id)
                    return Result.Success();

                return Result.Failure(new Error("EmployeeValidationRepository.ValidateEmployeeEmailIsUnique", $"An employee with email address {emailAddres} is already in the database."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeValidationRepository.ValidateEmployeeEmailIsUnique - {Helpers.GetExceptionMessage(ex)}");
                return Result.Failure(new Error("EmployeeValidationRepository.ValidateEmployeeEmailIsUnique", Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result> ValidateEmployeeExist(int id, bool asNoTracking = true)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var employee = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<EmployeeDataModel>().AsNoTracking(),
                        new ValidateEmployeeExistSpec(id)
                    )
                    .Select(s => new { s.BusinessEntityID })
                    .FirstOrDefaultAsync(cancellationToken);

                if (employee is not null)
                    return Result.Success();

                return Result.Failure(new Error("EmployeeValidationRepository.ValidateEmployeeExist", $"An employee with ID {id} could not be found."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeValidationRepository.ValidateEmployeeExist - {Helpers.GetExceptionMessage(ex)}");
                return Result.Failure(new Error("EmployeeValidationRepository.ValidateEmployeeExist", Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result> ValidateDepartmentExist(short id, bool asNoTracking = true)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var department = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<Department>().AsNoTracking(),
                        new ValidateDepartmentExistSpec(id)
                    )
                    .Select(s => new { s.DepartmentID })
                    .FirstOrDefaultAsync(cancellationToken);

                if (department is not null)
                    return Result.Success();

                return Result.Failure(new Error("EmployeeValidationRepository.ValidateDepartmentExist", $"A department with ID {id} could not be found."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeValidationRepository.ValidateDepartmentExist - {Helpers.GetExceptionMessage(ex)}");
                return Result.Failure(new Error("EmployeeValidationRepository.ValidateDepartmentExist", Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result> ValidateShiftExist(byte id, bool asNoTracking = true)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var shift = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<Shift>().AsNoTracking(),
                        new ValidateShiftExistSpec(id)
                    )
                    .Select(s => new { s.ShiftID })
                    .FirstOrDefaultAsync(cancellationToken);

                if (shift is not null)
                    return Result.Success();

                return Result.Failure(new Error("EmployeeValidationRepository.ValidateShiftExist", $"A shift with ID {id} could not be found."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeValidationRepository.ValidateShiftExist - {Helpers.GetExceptionMessage(ex)}");
                return Result.Failure(new Error("EmployeeValidationRepository.ValidateShiftExist", Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result> ValidateManagerExist(int id, bool asNoTracking = true)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var manager = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<EmployeeManager>().AsNoTracking(),
                        new ValidateEmployeeManagerExistSpec(id)
                    )
                    .Select(s => new { s.BusinessEntityID })
                    .FirstOrDefaultAsync(cancellationToken);

                if (manager is not null)
                    return Result.Success();

                return Result.Failure(new Error("EmployeeValidationRepository.ValidateManagerExist", $"A manager with ID {id} could not be found."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeValidationRepository.ValidateManagerExist - {Helpers.GetExceptionMessage(ex)}");
                return Result.Failure(new Error("EmployeeValidationRepository.ValidateManagerExist", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}