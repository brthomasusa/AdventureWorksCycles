#pragma warning disable S1116

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ardalis.Specification.EntityFrameworkCore;
using AWC.Core.Entities.HumanResources;
using AWC.Core.Interfaces.HumanResouces;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.Mappings.HumanResources;
using AWC.Infrastructure.Persistence.Specifications.Person;
using AWC.SharedKernel.Utilities;

using EmployeeDomainModel = AWC.Core.Entities.HumanResources.Employee;
using MapsterMapper;

namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class EmployeeWriteRepository : IEmployeeWriteRepository
    {
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;
        private readonly IMapper _mapper;

        public EmployeeWriteRepository(AwcContext ctx, ILogger<WriteRepositoryManager> logger, IMapper mapper)
        {
            _context = ctx;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Result<EmployeeDomainModel>> GetByIdAsync(int id, bool asNoTracking = false)
        {
            try
            {
                CancellationToken cancellationToken = default;

                var person = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        asNoTracking ? _context.Set<PersonDataModel>().AsNoTracking() : _context.Set<PersonDataModel>(),
                        new PersonByIDWithEmployeeSpec(id)
                    ).FirstOrDefaultAsync(cancellationToken);

                if (person is null)
                {
                    string errMsg = $"An employee with ID: {id} could not be found.";
                    return Result<EmployeeDomainModel>.Failure<EmployeeDomainModel>(new Error("EmployeeWriteRepository.GetByIdAsync", errMsg));
                }

                // Call a db udf that converts organization node of employee's manager to
                // an int BusinessEntityID. We then add that to the employee as ManagerID.
                var query = from emp in _context.Employee
                            where emp.BusinessEntityID == id
                            select new
                            {
                                ManagerID = _context.Get_Manager_ID(emp.BusinessEntityID)
                            };

                var result = query.FirstOrDefault();
                person.Employee!.ManagerID = result!.ManagerID;

                PersonDataModelToEmployeeDomainModelMapper dataMapper = new();
                Result<EmployeeDomainModel> employee = dataMapper.Map(person);

                if (employee.IsFailure)
                    return Result<EmployeeDomainModel>.Failure<EmployeeDomainModel>(new Error("EmployeeWriteRepository.GetByIdAsync", employee.Error.Message));

                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.GetByIdAsync - {Helpers.GetExceptionMessage(ex)}");
                return Result<EmployeeDomainModel>.Failure<EmployeeDomainModel>(new Error("EmployeeWriteRepository.GetByIdAsync",
                                                                                          Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result<int>> InsertAsync(Employee employee)
        {
            try
            {
                // Step 1: Map data from employee domain model to person data model                
                EmployeeDomainModelToPersonDataModelMapper modelMapper = new(_mapper);
                Result<PersonDataModel> personDataModel = modelMapper.Map(employee);

                if (personDataModel.IsFailure)
                {
                    return Result<int>.Failure<int>(new Error("EmployeeWriteRepository.InsertAsync",
                                                               personDataModel.Error.Message));
                }

                // Step 2: Start a transaction
                using var transaction = _context.Database.BeginTransaction();

                // Step 3: Insert addresses into database, address must exist before businessentityaddress
                await _context.Address!.AddAsync(personDataModel.Value.BusinessEntityAddresses.FirstOrDefault()!.Address!);

                // Step 4: Create a BusinessEntity instance and connect it to person data model
                BusinessEntity businessEntity = new() { PersonModel = personDataModel.Value };

                // Step 5: Update db and commit changes
                await _context.AddAsync(businessEntity);
                await _context.SaveChangesAsync();

                // Keep all of the hierarchy/orgnode stuff in the database
                object[] parameters = new object[]
                {
                    new SqlParameter("@paramEmployeeID", businessEntity.BusinessEntityID),
                    new SqlParameter("@paramManagerID", employee.ManagerID.Value)
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC HumanResources.uspUpdateEmployeeOrgNode @paramManagerID, @paramEmployeeID",
                    parameters
                );

                await transaction.CommitAsync();

                return businessEntity.BusinessEntityID;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeWriteRepository.InsertAsync - {Helpers.GetExceptionMessage(ex)}");
                return Result<int>.Failure<int>(new Error("EmployeeWriteRepository.InsertAsync",
                                                           Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result<int>> Update(EmployeeDomainModel employee)
        {
            try
            {
                EmployeeDomainModelToPersonDataModelMapper modelMapper = new(_mapper);
                Result<PersonDataModel> personDataModel = modelMapper.Map(employee);

                await UpdatePerson(personDataModel.Value);
                await UpdateEmployee(personDataModel.Value);
                await UpdateAddress(personDataModel.Value);
                await UpdateEmailAddress(personDataModel.Value);
                await UpdatePhoneNumber(personDataModel.Value);

                await _context.SaveChangesAsync();

                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeWriteRepository.Update - {Helpers.GetExceptionMessage(ex)}");
                return Result<int>.Failure<int>(new Error("EmployeeWriteRepository.Update",
                                                           Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result<int>> Delete(int entityID)
        {
            try
            {
                BusinessEntityAddress? bea = await _context.BusinessEntityAddress!.Where(b => b.BusinessEntityID == entityID).FirstOrDefaultAsync();
                int addressId = bea!.AddressID;

                using var transaction = _context.Database.BeginTransaction();

                // Delete PayHistories, DepartmentHistories and Employee
                await _context.EmployeePayHistory!.Where(e => e.BusinessEntityID == entityID).ExecuteDeleteAsync();
                await _context.EmployeeDepartmentHistory!.Where(e => e.BusinessEntityID == entityID).ExecuteDeleteAsync();
                await _context.Employee!.Where(e => e.BusinessEntityID == entityID).ExecuteDeleteAsync();

                // Delete Person.EmailAddress
                await _context.EmailAddress!.Where(email => email.BusinessEntityID == entityID).ExecuteDeleteAsync();

                // Delete Person.Phone
                await _context.PersonPhone!.Where(ph => ph.BusinessEntityID == entityID).ExecuteDeleteAsync();

                // Delete Person.PassWord
                await _context.Password!.Where(ph => ph.BusinessEntityID == entityID).ExecuteDeleteAsync();

                // Delete Person.BusinessEntityAddress
                await _context.BusinessEntityAddress!.Where(bea => bea.BusinessEntityID == entityID).ExecuteDeleteAsync();

                // Delete Person.Address                
                await _context.Address!.Where(a => a.AddressID == addressId).ExecuteDeleteAsync();

                // Delete Person.Person
                await _context.Person!.Where(p => p.BusinessEntityID == entityID).ExecuteDeleteAsync();

                // Finally, delete Person.BusinessEntity
                await _context.BusinessEntity!.Where(bea => bea.BusinessEntityID == entityID).ExecuteDeleteAsync();

                await transaction.CommitAsync();

                return Result<int>.Success<int>(0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeWriteRepository.Delete - {Helpers.GetExceptionMessage(ex)}");
                return Result<int>.Failure<int>(new Error("EmployeeWriteRepository.Delete",
                                                           Helpers.GetExceptionMessage(ex)));
            }
        }

        private async Task UpdatePerson(PersonDataModel dataModel)
            => await _context.Person!
                .Where(p => p.BusinessEntityID == dataModel.BusinessEntityID)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(person => person.PersonType, dataModel.PersonType)
                    .SetProperty(person => person.NameStyle, dataModel.NameStyle)
                    .SetProperty(person => person.Title, dataModel.Title)
                    .SetProperty(person => person.FirstName, dataModel.FirstName)
                    .SetProperty(person => person.MiddleName, dataModel.MiddleName)
                    .SetProperty(person => person.LastName, dataModel.LastName)
                    .SetProperty(person => person.Suffix, dataModel.Suffix)
                    .SetProperty(person => person.EmailPromotion, dataModel.EmailPromotion)
                );

        private async Task UpdateEmployee(PersonDataModel dataModel)
            => await _context.Employee!
                .Where(e => e.BusinessEntityID == dataModel.BusinessEntityID)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(emp => emp.NationalIDNumber, dataModel.Employee!.NationalIDNumber)
                    .SetProperty(emp => emp.LoginID, dataModel.Employee!.LoginID)
                    .SetProperty(emp => emp.JobTitle, dataModel.Employee!.JobTitle)
                    .SetProperty(emp => emp.BirthDate, dataModel.Employee!.BirthDate)
                    .SetProperty(emp => emp.MaritalStatus, dataModel.Employee!.MaritalStatus)
                    .SetProperty(emp => emp.Gender, dataModel.Employee!.Gender)
                    .SetProperty(emp => emp.HireDate, dataModel.Employee!.HireDate)
                    .SetProperty(emp => emp.SalariedFlag, dataModel.Employee!.SalariedFlag)
                    .SetProperty(emp => emp.VacationHours, dataModel.Employee!.VacationHours)
                    .SetProperty(emp => emp.SickLeaveHours, dataModel.Employee!.SickLeaveHours)
                    .SetProperty(emp => emp.CurrentFlag, dataModel.Employee!.CurrentFlag)
                );

        private async Task UpdateAddress(PersonDataModel dataModel)
        {
            Address address = dataModel.BusinessEntityAddresses.SingleOrDefault()!.Address!;

            await _context.Address!
                .Where(a => a.AddressID == address.AddressID)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(addr => addr.AddressLine1, address.AddressLine1)
                    .SetProperty(addr => addr.AddressLine2, address.AddressLine2)
                    .SetProperty(addr => addr.City, address.City)
                    .SetProperty(addr => addr.StateProvinceID, address.StateProvinceID)
                    .SetProperty(addr => addr.PostalCode, address.PostalCode)
                );
        }

        private async Task UpdateEmailAddress(PersonDataModel dataModel)
        {
            EmailAddress emailAddress = dataModel.EmailAddresses.SingleOrDefault()!;

            await _context.EmailAddress!
                .Where(a => a.BusinessEntityID == dataModel.BusinessEntityID)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(email => email.MailAddress, emailAddress.MailAddress)
                );
        }

        private async Task UpdatePhoneNumber(PersonDataModel dataModel)
        {
            PersonPhone phone = dataModel.Telephones.SingleOrDefault()!;

            await _context.PersonPhone!
                .Where(tel => tel.BusinessEntityID == dataModel.BusinessEntityID)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(ph => ph.PhoneNumber, phone.PhoneNumber)
                    .SetProperty(ph => ph.PhoneNumberTypeID, phone.PhoneNumberTypeID)
                );
        }

    }
}