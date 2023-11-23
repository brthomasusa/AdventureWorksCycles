#pragma warning disable S1854, S4487

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ardalis.Specification.EntityFrameworkCore;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.Core.Interfaces.HumanResouces;
using AWC.Infrastructure.Persistence.Specifications.HumanResources;
using AWC.SharedKernel.Interfaces;
using AWC.SharedKernel.Utilities;

using CompanyDataModel = AWC.Infrastructure.Persistence.DataModels.HumanResources.Company;
using CompanyDomainModel = AWC.Core.Entities.HumanResources.Company;
using MapsterMapper;

namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class CompanyWriteRepository : ICompanyWriteRepository
    {
        private const int SUCCESS_MARKER = 0;
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyWriteRepository(AwcContext ctx, ILogger<WriteRepositoryManager> logger, IMapper mapper)
        {
            _context = ctx;
            _unitOfWork = new UnitOfWork(_context);
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Result<CompanyDomainModel>> GetByIdAsync(int id, bool asNoTracking = false)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var companyDataModel = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        asNoTracking ? _context.Set<CompanyDataModel>().AsNoTracking() : _context.Set<CompanyDataModel>(),
                        new CompanyByIdSpec(id)
                    ).FirstOrDefaultAsync(cancellationToken);

                if (companyDataModel is null)
                {
                    string errMsg = $"Unable to retrieve company with ID: {id}";
                    _logger.LogWarning($"Code Path: CompanyAggregateRepository.GetByIdAsync - Message: {errMsg}");
                    return Result<CompanyDomainModel>.Failure<CompanyDomainModel>(new Error("CompanyAggregateRepository.GetByIdAsync", errMsg));
                }

                Result<AWC.Core.Entities.HumanResources.Company> result = CompanyDomainModel.Create(
                    new CompanyID(companyDataModel.CompanyID),
                    companyDataModel.CompanyName!,
                    companyDataModel.LegalName!,
                    companyDataModel.EIN!,
                    companyDataModel.WebsiteUrl!,
                    companyDataModel.MailAddressLine1!,
                    companyDataModel.DeliveryAddressLine2,
                    companyDataModel.MailCity!,
                    companyDataModel.MailStateProvinceID,
                    companyDataModel.MailPostalCode!,
                    companyDataModel.DeliveryAddressLine1!,
                    companyDataModel.DeliveryAddressLine2,
                    companyDataModel.DeliveryCity!,
                    companyDataModel.DeliveryStateProvinceID,
                    companyDataModel.DeliveryPostalCode!,
                    companyDataModel.Telephone!,
                    companyDataModel.Fax!
                );

                if (result.IsFailure)
                {
                    _logger.LogWarning($"Code Path: {result.Error.Code} - Message: {result.Error.Message}");
                    return Result<CompanyDomainModel>.Failure<CompanyDomainModel>(new Error("CompanyAggregateRepository.GetByIdAsync", result.Error.Message));
                }

                CompanyDomainModel companyDomainModel = result.Value;

                var departments = await _context.Department!.ToListAsync();
                if (departments.Any())
                {
                    departments.ForEach(dept => companyDomainModel.AddDepartment(new DepartmentID(dept.DepartmentID), dept.Name!, dept.GroupName!));
                }

                var shifts = await _context.Shift!.ToListAsync();
                if (shifts.Any())
                {
                    shifts.ForEach(shift => companyDomainModel.AddShift(
                        new ShiftID(shift.ShiftID), shift.Name!, shift.StartTime.Hours, shift.StartTime.Minutes, shift.EndTime.Hours, shift.EndTime.Minutes
                    ));
                }

                return companyDomainModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CompanyWriteRepository.GetByIdAsync - {Helpers.GetExceptionMessage(ex)}");
                return Result<CompanyDomainModel>.Failure<CompanyDomainModel>(new Error("EmployeeWriteRepository.GetByIdAsync",
                                                                                         Helpers.GetExceptionMessage(ex)));
            }
        }

        public Task<Result<int>> InsertAsync(CompanyDomainModel entity)
            => throw new NotImplementedException();

        public async Task<Result<int>> Update(CompanyDomainModel entity)
        {
            try
            {
                await _context.Company!
                    .Where(comp => comp.CompanyID == entity.Id.Value)
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(comp => comp.CompanyName, entity.CompanyName)
                        .SetProperty(comp => comp.LegalName, entity.LegalName!)
                        .SetProperty(comp => comp.EIN, entity.EIN)
                        .SetProperty(comp => comp.WebsiteUrl, entity.CompanyWebSite!)
                        .SetProperty(comp => comp.MailAddressLine1, entity.PostalAddress.AddressLine1)
                        .SetProperty(comp => comp.MailAddressLine2, entity.PostalAddress.AddressLine2)
                        .SetProperty(comp => comp.MailCity, entity.PostalAddress.City)
                        .SetProperty(comp => comp.MailStateProvinceID, entity.PostalAddress.StateProvinceID)
                        .SetProperty(comp => comp.MailPostalCode, entity.PostalAddress.PostalCode)
                        .SetProperty(comp => comp.DeliveryAddressLine1, entity.DeliveryAddress.AddressLine1)
                        .SetProperty(comp => comp.DeliveryAddressLine2, entity.DeliveryAddress.AddressLine2)
                        .SetProperty(comp => comp.DeliveryCity, entity.DeliveryAddress.City)
                        .SetProperty(comp => comp.DeliveryStateProvinceID, entity.DeliveryAddress.StateProvinceID)
                        .SetProperty(comp => comp.DeliveryPostalCode, entity.DeliveryAddress.PostalCode)
                        .SetProperty(comp => comp.Telephone, entity.Telephone)
                        .SetProperty(comp => comp.Fax, entity.Fax)
                    );

                await _unitOfWork.CommitAsync();

                return Result<int>.Success<int>(SUCCESS_MARKER);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CompanyWriteRepository.Update - {Helpers.GetExceptionMessage(ex)}");
                return Result<int>.Failure<int>(new Error("CompanyWriteRepository.Update",
                                                           Helpers.GetExceptionMessage(ex)));
            }
        }

        public Task<Result<int>> Delete(int entityID)
            => throw new NotImplementedException();
    }
}