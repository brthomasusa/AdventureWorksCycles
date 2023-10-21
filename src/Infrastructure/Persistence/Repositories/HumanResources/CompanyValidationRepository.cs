using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ardalis.Specification.EntityFrameworkCore;
using AWC.Core.Interfaces;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.Specifications.HumanResources;
using AWC.SharedKernel.Utilities;

namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class CompanyValidationRepository : ICompanyValidationRepository
    {
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;

        public CompanyValidationRepository(AwcContext ctx, ILogger<WriteRepositoryManager> logger)
        {
            _context = ctx;
            _logger = logger;
        }

        public async Task<Result> ValidateCompanyNameIsUnique(int id, string companyName, bool asNoTracking = true)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var company = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<Company>().AsNoTracking(),
                        new ValidateCompanyNameIsUniqueSpec(companyName)
                    )
                    .Select(c => new { c.CompanyID })
                    .FirstOrDefaultAsync(cancellationToken);

                if (company is null || company.CompanyID == id)
                    return Result.Success();

                return Result.Failure
                (
                    new Error
                    (
                        "CompanyValidationRepository.ValidateCompanyNameIsUnique",
                        $"A company named ${companyName} is already in the database."
                    )
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CompanyValidationRepository.ValidateCompanyNameIsUnique - {Helpers.GetExceptionMessage(ex)}");

                return Result.Failure
                (
                    new Error
                    (
                        "CompanyValidationRepository.ValidateCompanyNameIsUnique",
                        Helpers.GetExceptionMessage(ex)
                    )
                );
            }
        }
    }
}