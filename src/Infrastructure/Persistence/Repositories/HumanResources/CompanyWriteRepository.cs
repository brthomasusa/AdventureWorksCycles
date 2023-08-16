using Ardalis.Specification.EntityFrameworkCore;
using AWC.Core.Interfaces;
using AWC.Infrastructure.Persistence.Mappings.HumanResources;
using AWC.Infrastructure.Persistence.Specifications.HumanResources;
using AWC.SharedKernel.Interfaces;
using AWC.SharedKernel.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CompanyDataModel = AWC.Infrastructure.Persistence.DataModels.HumanResources.Company;
using CompanyDomainModel = AWC.Core.HumanResources.Company;

namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class CompanyWriteRepository : ICompanyWriteRepository
    {
        private const int SUCCESS_MARKER = 0;
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyWriteRepository(AwcContext ctx, ILogger<WriteRepositoryManager> logger)
        {
            _context = ctx;
            _unitOfWork = new UnitOfWork(_context);
            _logger = logger;
        }

        public async Task<Result<CompanyDomainModel>> GetByIdAsync(int companyId, bool asNoTracking = false)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var companyDataModel = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        asNoTracking ? _context.Set<CompanyDataModel>().AsNoTracking() : _context.Set<CompanyDataModel>(),
                        new CompanyByIdSpec(companyId)
                    ).FirstOrDefaultAsync(cancellationToken);

                if (companyDataModel is null)
                {
                    string errMsg = $"Unable to retrieve company with ID: {companyId}";
                    _logger.LogWarning($"Code Path: CompanyAggregateRepository.GetByIdAsync - Message: {errMsg}");
                    return Result<CompanyDomainModel>.Failure<CompanyDomainModel>(new Error("CompanyAggregateRepository.GetByIdAsync", errMsg));
                }

                Result<CompanyDomainModel> result = companyDataModel.MapToCompanyDomainObject();
                if (result.IsFailure)
                {
                    _logger.LogWarning($"Code Path: {result.Error.Code} - Message: {result.Error.Message}");
                    return Result<CompanyDomainModel>.Failure<CompanyDomainModel>(new Error("CompanyAggregateRepository.GetByIdAsync", result.Error.Message));
                }

                CompanyDomainModel companyDomainModel = result.Value;

                var departments = await _context.Department!.ToListAsync();
                if (departments.Any())
                {
                    departments.ForEach(dept => companyDomainModel.AddDepartment(dept.DepartmentID, dept.Name!, dept.GroupName!));
                }

                var shifts = await _context.Shift!.ToListAsync();
                if (shifts.Any())
                {
                    shifts.ForEach(shift => companyDomainModel.AddShift(
                        shift.ShiftID, shift.Name!, shift.StartTime.Hours, shift.StartTime.Minutes, shift.EndTime.Hours, shift.EndTime.Minutes
                    ));
                }

                return companyDomainModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CompanyAggregateRepository.GetByIdAsync - {Helpers.GetExceptionMessage(ex)}");
                return Result<CompanyDomainModel>.Failure<CompanyDomainModel>(new Error("EmployeeAggregateRepository.GetByIdAsync",
                                                                                         Helpers.GetExceptionMessage(ex)));
            }
        }

        public Task<Result<int>> InsertAsync(CompanyDomainModel entity) => throw new NotImplementedException();

        public async Task<Result<int>> Update(CompanyDomainModel entity)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var companyDataModel = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<CompanyDataModel>(),
                        new CompanyByIdSpec(entity.Id)
                    ).FirstOrDefaultAsync(cancellationToken);

                if (companyDataModel is null)
                {
                    string errMsg = $"Update failed. Unable to retrieve company with ID: {entity.Id}";
                    _logger.LogWarning($"Code Path: CompanyAggregateRepository.Update - Message: {errMsg}");
                    return Result<int>.Failure<int>(new Error("CompanyAggregateRepository.Update", errMsg));
                }

                companyDataModel.CompanyName = entity.CompanyName;
                companyDataModel.LegalName = entity.LegalName!;
                companyDataModel.EIN = entity.EIN;
                companyDataModel.WebsiteUrl = entity.CompanyWebSite!;
                companyDataModel.MailAddressLine1 = entity.PostalAddress.AddressLine1;
                companyDataModel.MailAddressLine2 = entity.PostalAddress.AddressLine2;
                companyDataModel.MailCity = entity.PostalAddress.City;
                companyDataModel.MailStateProvinceID = entity.PostalAddress.StateProvinceID;
                companyDataModel.MailPostalCode = entity.PostalAddress.Zipcode;
                companyDataModel.DeliveryAddressLine1 = entity.DeliveryAddress.AddressLine1;
                companyDataModel.DeliveryAddressLine2 = entity.DeliveryAddress.AddressLine2;
                companyDataModel.DeliveryCity = entity.DeliveryAddress.City;
                companyDataModel.DeliveryStateProvinceID = entity.DeliveryAddress.StateProvinceID;
                companyDataModel.DeliveryPostalCode = entity.DeliveryAddress.Zipcode;
                companyDataModel.Telephone = entity.Telephone;
                companyDataModel.Fax = entity.Fax;

                await _unitOfWork.CommitAsync();

                return Result<int>.Success<int>(SUCCESS_MARKER);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CompanyAggregateRepository.Update - {Helpers.GetExceptionMessage(ex)}");
                return Result<int>.Failure<int>(new Error("CompanyAggregateRepository.Update",
                                                           Helpers.GetExceptionMessage(ex)));
            }
        }

        public Task<Result<int>> Delete(int entityID) => throw new NotImplementedException();
    }
}