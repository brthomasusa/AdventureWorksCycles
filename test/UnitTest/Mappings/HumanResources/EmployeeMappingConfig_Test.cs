using AWC.Application.Features.HumanResources.Common;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Core.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.UnitTest.Data;

using MapsterMapper;

namespace AWC.UnitTest.Mappings.HumanResources
{
    public class EmployeeMappingConfig_Test
    {
        private readonly IMapper _mapper;
        private readonly Employee _employee;

        public EmployeeMappingConfig_Test()
        {
            _mapper = AddMapsterForUnitTests.GetMapper();

            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();
            Result<Employee> result = BuildEmployeeDomainObject.Build(command, _mapper);
            _employee = result.Value;
        }

        [Fact]
        public void EmployeeMappingConfig_EmployeeDomainObj_EmployeeDataObj_ShouldSucceed()
        {
            EmployeeDataModel employeeDataModel = _mapper.Map<EmployeeDataModel>(_employee);
            Assert.NotNull(employeeDataModel);
        }

        [Fact]
        public void EmployeeMappingConfig_EmployeeDomainObj_PersonDataObj_ShouldSucceed()
        {
            PersonDataModel personDataModel = _mapper.Map<PersonDataModel>(_employee);
            Assert.NotNull(personDataModel);
        }

        [Fact]
        public void EmployeeMappingConfig_EmployeeDomainObj_EmployeeDataObj_AddPayHistories_ShouldSucceed()
        {
            // This testing Mapster mapping from PayHistory to EmployeePayHistory (domain model to data model)
            EmployeeDataModel employeeDataModel = _mapper.Map<EmployeeDataModel>(_employee);

            _employee.PayHistories.ToList().ForEach(pay =>
                employeeDataModel.PayHistories.Add(_mapper.Map<EmployeePayHistory>(pay))
            );

            Assert.NotEmpty(employeeDataModel.PayHistories);
        }

        [Fact]
        public void EmployeeMappingConfig_EmployeeDomainObj_EmployeeDataObj_AddDepartmentHistories_ShouldSucceed()
        {
            // This testing Mapster mapping from DepartmentHistory to EmployeeDepartmentHistory (domain model to data model)
            EmployeeDataModel employeeDataModel = _mapper.Map<EmployeeDataModel>(_employee);

            _employee.DepartmentHistories.ToList().ForEach(dept =>
                employeeDataModel.DepartmentHistories.Add(_mapper.Map<EmployeeDepartmentHistory>(dept))
            );

            Assert.NotEmpty(employeeDataModel.DepartmentHistories);
        }

        [Fact]
        public void EmployeeMappingConfig_EmployeeDomainObj_PersonDataObj_AddEmailAddress_ShouldSucceed()
        {
            // This tests Mapster mapping from domain model EmailAddress to data model EmailAddress 
            PersonDataModel personDataModel = _mapper.Map<PersonDataModel>(_employee);

            _employee.EmailAddresses.ToList().ForEach(email =>
                personDataModel.EmailAddresses.Add(_mapper.Map<AWC.Infrastructure.Persistence.DataModels.Person.EmailAddress>(email))
            );

            Assert.NotEmpty(personDataModel.EmailAddresses);
        }

        [Fact]
        public void EmployeeMappingConfig_EmployeeDomainObj_PersonDataObj_AddPersonPhone_ShouldSucceed()
        {
            // This tests Mapster mapping from domain model EmailAddress to data model EmailAddress 
            PersonDataModel personDataModel = _mapper.Map<PersonDataModel>(_employee);

            _employee.Telephones.ToList().ForEach(tel =>
                personDataModel.Telephones.Add(_mapper.Map<AWC.Infrastructure.Persistence.DataModels.Person.PersonPhone>(tel))
            );

            Assert.NotEmpty(personDataModel.Telephones);
        }

        [Fact]
        public void EmployeeMappingConfig_EmployeeDomainObj_PersonDataObj_AddBusinessEntityAddress_ShouldSucceed()
        {
            // This tests Mapster mapping from domain model EmailAddress to data model EmailAddress 
            PersonDataModel personDataModel = _mapper.Map<PersonDataModel>(_employee);

            _employee.Addresses.ToList().ForEach(addr =>
                personDataModel.BusinessEntityAddresses.Add(
                    new BusinessEntityAddress
                    {
                        BusinessEntityID = addr.BusinessEntityID,
                        AddressID = addr.Id,
                        Address = new()
                        {
                            AddressID = addr.Id,
                            AddressLine1 = addr.Location.AddressLine1,
                            AddressLine2 = addr.Location.AddressLine2,
                            City = addr.Location.City,
                            StateProvinceID = addr.Location.StateProvinceID,
                            PostalCode = addr.Location.Zipcode
                        },
                    }
                )
            );

            AWC.Core.Shared.Address domainAddress = _employee.Addresses.FirstOrDefault()!;
            AWC.Infrastructure.Persistence.DataModels.Person.Address dataAddress = personDataModel.BusinessEntityAddresses.FirstOrDefault()!.Address!;

            Assert.Equal(domainAddress.Location.AddressLine1, dataAddress.AddressLine1);
            Assert.Equal(domainAddress.Location.AddressLine2, dataAddress.AddressLine2);
            Assert.Equal(domainAddress.Location.City, dataAddress.City);
            Assert.Equal(domainAddress.Location.StateProvinceID, dataAddress.StateProvinceID);
            Assert.Equal(domainAddress.Location.Zipcode, dataAddress.PostalCode);
        }
    }
}