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
                        asNoTracking ? _context.Set<PersonDataModel>().AsNoTracking() : _context.Set<PersonDataModel>(),
                        new ValidateEmployeeNameIsUniqueSpec(fname, lname, middleName)
                    )
                    .Select(s => new { EmployeeID = s.BusinessEntityID, s.FirstName, s.MiddleName, s.LastName })
                    .FirstOrDefaultAsync(cancellationToken);

                if (person is null || person.EmployeeID == id)
                    return Result.Success();

                return Result.Failure
                (
                    new Error
                    (
                        "EmployeeAggregateRepository.ValidatePersonNameIsUnique",
                        $"A person named ${fname} {middleName} {lname} is already in the database."
                    )
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.ValidatePersonNameIsUnique - {Helpers.GetExceptionMessage(ex)}");

                return Result.Failure
                (
                    new Error
                    (
                        "EmployeeAggregateRepository.ValidatePersonNameIsUnique",
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

                var nationalId = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        asNoTracking ? _context.Set<EmployeeDataModel>().AsNoTracking() : _context.Set<EmployeeDataModel>(),
                        new ValidateNationalIdNumberIsUniqueSpec(nationalIdNumber)
                    )
                    .Select(s => new { EmployeeID = s.BusinessEntityID, NationalID = s.NationalIDNumber })
                    .FirstOrDefaultAsync(cancellationToken);

                if (nationalId is null || nationalId.EmployeeID == id)
                    return Result.Success();

                return Result.Failure(new Error("EmployeeAggregateRepository.ValidateNationalIdNumberIsUnique", $"An employee with natioanal ID {nationalIdNumber} is already in the database."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.ValidateNationalIdNumberIsUnique - {Helpers.GetExceptionMessage(ex)}");
                return Result.Failure(new Error("EmployeeAggregateRepository.ValidateNationalIdNumberIsUnique.", Helpers.GetExceptionMessage(ex)));
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
                        asNoTracking ? _context.Set<PersonDataModel>().AsNoTracking() : _context.Set<PersonDataModel>(),
                        new ValidateEmployeeEmailIsUniqueSpec(emailAddres)
                    ).FirstOrDefaultAsync(cancellationToken);

                if (email is null || email.BusinessEntityID == id)
                    return Result.Success();

                return Result.Failure(new Error("EmployeeAggregateRepository.ValidateEmployeeEmailIsUnique", $"An employee with email address {emailAddres} is already in the database."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.ValidateEmployeeEmailIsUnique - {Helpers.GetExceptionMessage(ex)}");
                return Result.Failure(new Error("EmployeeAggregateRepository.ValidateEmployeeEmailIsUnique", Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result> ValidateEmployeeExist(int id, bool asNoTracking = true)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var employeeId = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        asNoTracking ? _context.Set<EmployeeDataModel>().AsNoTracking() : _context.Set<EmployeeDataModel>(),
                        new ValidateEmployeeExistSpec(id)
                    )
                    .Select(s => new { EmployeeID = s.BusinessEntityID })
                    .FirstOrDefaultAsync(cancellationToken);

                if (employeeId is not null)
                    return Result.Success();

                return Result.Failure(new Error("EmployeeAggregateRepository.ValidateEmployeeExist", $"An employee with ID {id} could not be found."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.ValidateEmployeeExist - {Helpers.GetExceptionMessage(ex)}");
                return Result.Failure(new Error("EmployeeAggregateRepository.ValidateEmployeeExist", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}