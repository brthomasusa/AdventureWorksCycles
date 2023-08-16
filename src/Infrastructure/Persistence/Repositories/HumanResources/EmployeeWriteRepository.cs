using Ardalis.Specification.EntityFrameworkCore;
using AWC.Core.Interfaces;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.Mappings.HumanResources;
using AWC.Infrastructure.Persistence.Specifications.Person;
using AWC.SharedKernel.Interfaces;
using AWC.SharedKernel.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EmployeeDataModel = AWC.Infrastructure.Persistence.DataModels.HumanResources.EmployeeDataModel;
using EmployeeDomainModel = AWC.Core.HumanResources.Employee;



namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class EmployeeWriteRepository : IEmployeeWriteRepository
    {
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeWriteRepository(AwcContext ctx, ILogger<WriteRepositoryManager> logger)
        {
            _context = ctx;
            _unitOfWork = new UnitOfWork(_context);
            _logger = logger;
        }

        public async Task<Result<EmployeeDomainModel>> GetByIdAsync(int employeeID, bool asNoTracking = false)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var person = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        asNoTracking ? _context.Set<PersonDataModel>().AsNoTracking() : _context.Set<PersonDataModel>(),
                        new PersonByIDWithEmployeeSpec(employeeID)
                    ).FirstOrDefaultAsync(cancellationToken);

                if (person is null)
                {
                    string errMsg = $"An employee with ID: {employeeID} could not be found.";
                    return Result<EmployeeDomainModel>.Failure<EmployeeDomainModel>(new Error("EmployeeAggregateRepository.GetByIdAsync", errMsg));
                }

                // Call a db udf that converts organization node of 
                // employee's manager to an int BusinessEntityID. We then
                // add that to the employee as ManagerID.
                var query = from emp in _context.Employee
                            where emp.BusinessEntityID == employeeID
                            select new
                            {
                                ManagerID = _context.Get_Manager_ID(emp.BusinessEntityID)
                            };

                var queryResult = query.FirstOrDefault();
                person.Employee!.ManagerID = queryResult!.ManagerID;

                Result<EmployeeDomainModel> result = person!.MapToEmployeeDomainObject();

                if (result.IsFailure)
                {
                    return Result<EmployeeDomainModel>.Failure<EmployeeDomainModel>(new Error("EmployeeAggregateRepository.GetByIdAsync", result.Error.Message));
                }

                EmployeeDomainModel? employee = result.Value;

                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.GetByIdAsync - {Helpers.GetExceptionMessage(ex)}");
                return Result<EmployeeDomainModel>.Failure<EmployeeDomainModel>(new Error("EmployeeAggregateRepository.GetByIdAsync",
                                                                                          Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result<int>> InsertAsync(EmployeeDomainModel employee)
        {
            try
            {
                using var transaction = _context.Database.BeginTransaction();

                AWC.Core.Shared.Address? domainAddress = employee.Addresses.FirstOrDefault() ??
                    throw new Exception("Unable to retrieve employee address from Employee domain object.");

                AWC.Infrastructure.Persistence.DataModels.Person.Address dataModelAddress = new()
                {
                    AddressLine1 = domainAddress.Location.AddressLine1,
                    AddressLine2 = domainAddress.Location.AddressLine2,
                    City = domainAddress.Location.City,
                    StateProvinceID = domainAddress.Location.StateProvinceID,
                    PostalCode = domainAddress.Location.Zipcode
                };

                await _context.AddAsync(dataModelAddress);
                await _context.SaveChangesAsync();

                PersonDataModel personDataModel = employee.MapToPersonDataModelForCreate();

                BusinessEntityAddress businessEntityAddress = new()
                {
                    BusinessEntityID = personDataModel.BusinessEntityID,
                    AddressID = dataModelAddress.AddressID,
                    Address = dataModelAddress,
                    AddressTypeID = (int)domainAddress.AddressType
                };

                personDataModel.BusinessEntityAddresses.Add(businessEntityAddress);

                BusinessEntity entity = new()
                {
                    PersonModel = personDataModel
                };

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                // Keep all of the hierarchy/orgnode stuff in the database
                object[] parameters = new object[]
                {
                    new SqlParameter("@paramEmployeeID", entity.BusinessEntityID),
                    new SqlParameter("@paramManagerID", employee.ManagerID.Value)
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC HumanResources.uspUpdateEmployeeOrgNode @paramManagerID, @paramEmployeeID",
                    parameters
                );

                await transaction.CommitAsync();

                return entity.BusinessEntityID;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.InsertAsync - {Helpers.GetExceptionMessage(ex)}");
                return Result<int>.Failure<int>(new Error("EmployeeAggregateRepository.InsertAsync",
                                                           Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result<int>> Update(EmployeeDomainModel employee)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var person = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<PersonDataModel>().AsTracking(),
                        new PersonByIDWithEmployeeSpec(employee.Id)
                    ).FirstOrDefaultAsync(cancellationToken);

                if (person is not null)
                {
                    employee.MapToPersonDataModelForUpdate(ref person);
                    _context.Person!.Update(person);
                    await _unitOfWork.CommitAsync();

                    return Result<int>.Success<int>(0);
                }
                else
                {
                    return Result<int>.Failure<int>(new Error("EmployeeAggregateRepository.Update",
                                                              $"Failed to retrieve employee with ID: {employee.Id} for editing."));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.Update - {Helpers.GetExceptionMessage(ex)}");
                return Result<int>.Failure<int>(new Error("EmployeeAggregateRepository.Update",
                                                           Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result<int>> Delete(int entityID)
        {
            try
            {
                BusinessEntity? entity = await _context.BusinessEntity!.FindAsync(4);

                if (entity is null)
                    return Result<int>.Failure<int>(new Error("EmployeeAggregateRepository.Delete", $"Failed to retrieve employee with ID: {entityID} for deletion."));

                _context.BusinessEntity!.Remove(entity);
                await _unitOfWork.CommitAsync();
                return Result<int>.Success<int>(0);


                // EmployeeDataModel? employee = await _context.Employee!.FindAsync(entityID);
                // PersonDataModel? person = await _context.Person!.FindAsync(entityID);
                // BusinessEntity? businessEntity = await _context.BusinessEntity!.FindAsync(entityID);

                // if (employee is not null && person is not null && businessEntity is not null)
                // {
                //     RemovePayHistories(entityID);
                //     RemoveDepartmentHistories(entityID);
                //     RemovePersonPhones(entityID);
                //     RemovePersonEmailAddresses(entityID);
                //     RemovePersonPasswords(entityID);
                //     RemoveBusinessEntityAddresses(entityID);

                //     _context.Employee!.Remove(employee);
                //     _context.Person!.Remove(person);
                //     _context.BusinessEntity!.Remove(businessEntity);

                //     await _unitOfWork.CommitAsync();
                //     return Result<int>.Success<int>(0);
                // }
                // else
                // {
                //     return Result<int>.Failure<int>(new Error("EmployeeAggregateRepository.Delete",
                //                                               
                // }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.Delete - {Helpers.GetExceptionMessage(ex)}");
                return Result<int>.Failure<int>(new Error("EmployeeAggregateRepository.Delete",
                                                           Helpers.GetExceptionMessage(ex)));
            }
        }

        private void RemovePayHistories(int employeeID)
        {
            if (_context.EmployeePayHistory!.Where(hist => hist.BusinessEntityID == employeeID).Any())
            {
                var histories = _context.EmployeePayHistory!.Where(hist => hist.BusinessEntityID == employeeID).ToList();
                _context.EmployeePayHistory!.RemoveRange(histories);
            }
        }

        private void RemoveDepartmentHistories(int employeeID)
        {
            if (_context.EmployeeDepartmentHistory!.Where(hist => hist.BusinessEntityID == employeeID).Any())
            {
                var histories = _context.EmployeeDepartmentHistory!.Where(hist => hist.BusinessEntityID == employeeID).ToList();
                _context.EmployeeDepartmentHistory!.RemoveRange(histories);
            }
        }

        private void RemovePersonPhones(int employeeID)
        {
            if (_context.PersonPhone!.Where(ph => ph.BusinessEntityID == employeeID).Any())
            {
                var phones = _context.PersonPhone!.Where(ph => ph.BusinessEntityID == employeeID).ToList();
                _context.PersonPhone!.RemoveRange(phones);
            }
        }

        private void RemovePersonPasswords(int employeeID)
        {
            if (_context.Password!.Where(pw => pw.BusinessEntityID == employeeID).Any())
            {
                var passwords = _context.Password!.Where(pw => pw.BusinessEntityID == employeeID).ToList();
                _context.Password!.RemoveRange(passwords);
            }
        }

        private void RemovePersonEmailAddresses(int employeeID)
        {
            if (_context.EmailAddress!.Where(addr => addr.BusinessEntityID == employeeID).Any())
            {
                var addresses = _context.EmailAddress!.Where(addr => addr.BusinessEntityID == employeeID).ToList();
                _context.EmailAddress!.RemoveRange(addresses);
            }
        }

        private void RemoveBusinessEntityAddresses(int employeeID)
        {
            if (_context.BusinessEntityAddress!.Where(addr => addr.BusinessEntityID == employeeID).Any())
            {
                var businessEntityAddresses = _context.BusinessEntityAddress!.Where(addr => addr.BusinessEntityID == employeeID).ToList();
                _context.BusinessEntityAddress!.RemoveRange(businessEntityAddresses);

                RemoveAddresses(employeeID);
            }
        }

        private void RemoveAddresses(int employeeID)
        {
            int[] addressIDs = _context
                .BusinessEntityAddress!
                .Where(addr => addr.BusinessEntityID == employeeID)
                .Select(addr => addr.AddressID)
                .ToArray<int>();

            var addresses = _context.Address!.Where(addr => addressIDs.Contains(addr.AddressID)).ToList();

            if (addresses.Any())
                _context.Address!.RemoveRange(addresses);
        }





















    }
}