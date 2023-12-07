using AWC.Core.Entities.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.SharedKernel.Interfaces;
using AWC.SharedKernel.Utilities;
using Mapster;
using MapsterMapper;

namespace AWC.Infrastructure.Persistence.Mappings.HumanResources
{
    public class EmployeeDomainModelToPersonDataModelMapper : ModelMapper<Employee, PersonDataModel>
    {
        private readonly IMapper _mapper;

        public EmployeeDomainModelToPersonDataModelMapper(IMapper mapper)
            => _mapper = mapper;

        public override Result<PersonDataModel> Map(Employee domainModel)
        {
            try
            {
                PersonDataModel personDataModel = _mapper.Map<PersonDataModel>(domainModel);
                personDataModel.Employee = _mapper.Map<EmployeeDataModel>(domainModel);

                List<PayHistory> payHistories = domainModel.PayHistories.ToList();
                personDataModel.Employee.PayHistories = payHistories.Adapt<List<EmployeePayHistory>>();

                List<DepartmentHistory> departmentHistories = domainModel.DepartmentHistories.ToList();
                departmentHistories.ForEach(dept =>
                    personDataModel.Employee.DepartmentHistories.Add(_mapper.Map<EmployeeDepartmentHistory>(dept))
                );

                List<Core.Entities.Shared.PersonEmailAddress> emailAddresses = domainModel.EmailAddresses.ToList();
                emailAddresses.ForEach(email =>
                    {
                        var emailAddress = _mapper.Map<Infrastructure.Persistence.DataModels.Person.EmailAddress>(email);
                        emailAddress.BusinessEntityID = personDataModel.BusinessEntityID;
                        personDataModel.EmailAddresses.Add(emailAddress);
                    }
                );

                List<Core.Entities.Shared.PersonPhone> phones = domainModel.Telephones.ToList();
                phones.ForEach(tel =>
                    {
                        var phone = _mapper.Map<Infrastructure.Persistence.DataModels.Person.PersonPhone>(tel);
                        phone.BusinessEntityID = personDataModel.BusinessEntityID;
                        personDataModel.Telephones.Add(phone);
                    }
                );

                List<Core.Entities.Shared.Address> addresses = domainModel.Addresses.ToList();
                addresses.ForEach(addr =>
                {
                    BusinessEntityAddress bea = new()
                    {
                        BusinessEntityID = personDataModel.BusinessEntityID,
                        AddressID = addr.Id.Value,
                        Address = _mapper.Map<Infrastructure.Persistence.DataModels.Person.Address>(addr),
                        AddressTypeID = (int)addr.AddressType
                    };
                    personDataModel.BusinessEntityAddresses.Add(bea);
                });

                return personDataModel;
            }
            catch (Exception ex)
            {
                return Result<PersonDataModel>.Failure<PersonDataModel>(new Error("EmployeeDomainModelToPersonDataModelMapper.Map",
                                                                        Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}