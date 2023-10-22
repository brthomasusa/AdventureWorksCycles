#pragma warning disable S1116

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ardalis.Specification.EntityFrameworkCore;
using AWC.Core.Interfaces;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.Mappings.HumanResources;
using AWC.Infrastructure.Persistence.Specifications.Person;
using AWC.SharedKernel.Interfaces;
using AWC.SharedKernel.Utilities;

using EmployeeDomainModel = AWC.Core.HumanResources.Employee;
using MapsterMapper;

namespace AWC.Infrastructure.Persistence.Repositories.HumanResources
{
    public sealed class EmployeeWriteRepository : IEmployeeWriteRepository
    {
        private readonly ILogger<WriteRepositoryManager> _logger;
        private readonly AwcContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeWriteRepository(AwcContext ctx, ILogger<WriteRepositoryManager> logger, IMapper mapper)
        {
            _context = ctx;
            _unitOfWork = new UnitOfWork(_context);
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

                Result<EmployeeDomainModel> employeeDomainResult = person.MapToEmployeeDomainModel();

                if (employeeDomainResult.IsFailure)
                    return Result<EmployeeDomainModel>.Failure<EmployeeDomainModel>(new Error("EmployeeWriteRepository.GetByIdAsync", employeeDomainResult.Error.Message));

                EmployeeDomainModel employee = employeeDomainResult.Value;

                // Add department histories
                person.MapDepartmentHistories(ref employee);

                // Add pay histories
                person.MapPayHistories(ref employee);

                // Add addresses
                person.MapAddresses(ref employee);

                // Add email addresses
                person.MapEmailAddresses(ref employee);

                // Add person phones
                person.MapPersonPhones(ref employee);

                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"EmployeeAggregateRepository.GetByIdAsync - {Helpers.GetExceptionMessage(ex)}");
                return Result<EmployeeDomainModel>.Failure<EmployeeDomainModel>(new Error("EmployeeWriteRepository.GetByIdAsync",
                                                                                          Helpers.GetExceptionMessage(ex)));
            }
        }

        public async Task<Result<int>> InsertAsync(EmployeeDomainModel employee)
        {
            try
            {
                // Step 1: Get a list of data model addresses. These need to be inserted first.
                List<AWC.Infrastructure.Persistence.DataModels.Person.Address> addresses = GetDataModelAddresses(employee);

                PersonDataModel person = _mapper.Map<PersonDataModel>(employee);

                // Step 2: Create a list of BusinessEntityAddresses and add it to PersonDataModel
                CreateBusinessEntityAddresses(employee, ref person);

                // Step 3: Add email addresses from employee domain obj to person data model
                employee.EmailAddresses.ToList().ForEach(email =>
                    person.EmailAddresses.Add(_mapper.Map<AWC.Infrastructure.Persistence.DataModels.Person.EmailAddress>(email))
                );

                // Step 4: Add person phones to person data model
                employee.Telephones.ToList().ForEach(tel =>
                    person.Telephones.Add(_mapper.Map<AWC.Infrastructure.Persistence.DataModels.Person.PersonPhone>(tel))
                );

                // Step 5: Extract an EmployeeDataModel from the employee domain obj
                EmployeeDataModel employeeDataModel = _mapper.Map<EmployeeDataModel>(employee);

                // Step 6: Add department histories to employee data model
                employee.DepartmentHistories.ToList().ForEach(dept =>
                    employeeDataModel.DepartmentHistories.Add(_mapper.Map<EmployeeDepartmentHistory>(dept))
                );

                // Step 7: Add pay histories to employee data model
                employee.PayHistories.ToList().ForEach(pay =>
                    employeeDataModel.PayHistories.Add(_mapper.Map<EmployeePayHistory>(pay))
                );

                // Step 8: Add employee data model to person data model
                person.Employee = employeeDataModel;

                // Step 9: Start a transaction
                using var transaction = _context.Database.BeginTransaction();

                // Step 10: Insert addresses into database
                await _context.AddRangeAsync(addresses);
                await _context.SaveChangesAsync();

                // Step 10: Create a BusinessEntity instance and connect it to person data model
                BusinessEntity businessEntity = new() { PersonModel = person };
                await _context.SaveChangesAsync();

                // Step 11: Update db and commit changes
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
                CancellationToken cancellationToken = default;

                var person = await
                    SpecificationEvaluator.Default.GetQuery
                    (
                        _context.Set<PersonDataModel>().AsTracking(),
                        new PersonByIDWithEmployeeSpec(employee.Id)
                    ).FirstOrDefaultAsync(cancellationToken);

                if (person is not null)
                {
                    employee.MapToPersonDataModel(ref person);
                    _context.Person!.Update(person);
                    await _unitOfWork.CommitAsync();

                    return Result<int>.Success<int>(0);
                }
                else
                {
                    return Result<int>.Failure<int>(new Error("EmployeeWriteRepository.Update",
                                                              $"Failed to retrieve employee with ID: {employee.Id} for editing."));
                }
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

        private static List<AWC.Infrastructure.Persistence.DataModels.Person.Address> GetDataModelAddresses
        (
            AWC.Core.HumanResources.Employee employee
        )
        {
            List<AWC.Infrastructure.Persistence.DataModels.Person.Address> addresses = new();
            employee.Addresses.ToList().ForEach(addr =>
                addresses.Add(
                    new()
                    {
                        AddressID = addr.Id,
                        AddressLine1 = addr.Location.AddressLine1,
                        AddressLine2 = addr.Location.AddressLine2,
                        City = addr.Location.City,
                        StateProvinceID = addr.Location.StateProvinceID,
                        PostalCode = addr.Location.Zipcode
                    }
                )
            );

            return addresses;
        }

        private static void CreateBusinessEntityAddresses
        (
            AWC.Core.HumanResources.Employee employee,
            ref PersonDataModel person
        )
        {
            foreach (AWC.Core.Shared.Address addr in employee.Addresses)
            {
                person.BusinessEntityAddresses.Add(
                    new BusinessEntityAddress
                    {
                        BusinessEntityID = employee.Id,
                        AddressID = addr.Id,
                        Address = new Address
                        {
                            AddressID = addr.Id,
                            AddressLine1 = addr.Location.AddressLine1,
                            AddressLine2 = addr.Location.AddressLine2,
                            City = addr.Location.City,
                            StateProvinceID = addr.Location.StateProvinceID,
                            PostalCode = addr.Location.Zipcode
                        },
                        AddressTypeID = (int)addr.AddressType
                    }
                );
            };
        }
    }
}