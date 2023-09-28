using Ardalis.Specification.EntityFrameworkCore;
using AWC.Infrastructure.Persistence.DataModels.HumanResources;
using AWC.Infrastructure.Persistence.DataModels.Person;
using AWC.Infrastructure.Persistence.Specifications.HumanResources;
using AWC.Infrastructure.Persistence.Specifications.Person;
using Microsoft.EntityFrameworkCore;

namespace AWC.IntegrationTests.DbContext
{
    [Collection("Database Test")]
    public class PersonAndHrSpecification_Test : TestBase
    {
        [Fact]
        public async Task PersonByIDWithEmployeeSpecification_ReturnOnePersonWithEmployee_ShouldSucceed()
        {
            //SETUP

            const int businessEntityID = 2;
            CancellationToken cancellationToken = default;

            //ATTEMPT
            PersonDataModel? person = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<PersonDataModel>().AsNoTracking(),
                    new PersonByIDWithEmployeeSpec(businessEntityID)
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.Equal("Duffy", person!.LastName);
            Assert.Equal("245797967", person.Employee!.NationalIDNumber);
        }

        [Fact]
        public async Task PersonByLastNameWithEmployeeSpecification_OneLetterCriteria_ShouldSucceed()
        {
            //SETUP

            const string lastNameFragment = "a";
            CancellationToken cancellationToken = default;

            //ATTEMPT
            var people = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<PersonDataModel>(),
                    new PersonByLastNameWithEmployeeSpec(lastNameFragment)
                ).ToListAsync(cancellationToken);

            //VERIFY
            Assert.True(people.Any());
        }

        [Fact]
        public async Task ValidateEmployeeNameIsUniqueSpec_NameIsUnique_ShouldReturnNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT
            var person = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<PersonDataModel>(),
                    new ValidateEmployeeNameIsUniqueSpec("John", "Doe", "J")
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.Null(person);
        }

        [Fact]
        public async Task ValidateEmployeeNameIsUniqueSpec_NameIsNotUnique_ShouldReturnNotNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT
            var person = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<PersonDataModel>(),
                    new ValidateEmployeeNameIsUniqueSpec("David", "Bradley", "M")
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.NotNull(person);
        }

        [Fact]
        public async Task ValidateNationalIdNumberIsUniqueSpec_IDIsUnique_ShouldReturnNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT
            var employee = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<EmployeeDataModel>().AsNoTracking(),
                    new ValidateNationalIdNumberIsUniqueSpec("295847004")
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.Null(employee);
        }

        [Fact]
        public async Task ValidateNationalIdNumberIsUniqueSpec_IDIsNotUnique_ShouldReturnNotNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT
            var employee = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<EmployeeDataModel>(),
                    new ValidateNationalIdNumberIsUniqueSpec("295847284")
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.NotNull(employee);
        }

        [Fact]
        public async Task ValidateEmployeeEmailIsUnique_EmailIsUnique_ShouldReturnNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT
            var person = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<PersonDataModel>(),
                    new ValidateEmployeeEmailIsUniqueSpec("kerri0@adventure-works.com")
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.Null(person);
        }

        [Fact]
        public async Task ValidateEmployeeEmailIsUnique_EmailIsNotUnique_ShouldReturnNotNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT
            var person = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<PersonDataModel>(),
                    new ValidateEmployeeEmailIsUniqueSpec("terri0@adventure-works.com")
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.NotNull(person);
        }

        [Fact]
        public async Task ValidateEmployeeManagerExistSpec_ValidID_ShouldReturnNotNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT
            var mgr = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<EmployeeManager>(),
                    new ValidateEmployeeManagerExistSpec(1)
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.NotNull(mgr);
        }

        [Fact]
        public async Task ValidateEmployeeManagerExistSpec_InvalidID_ShouldReturnNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT
            var mgr = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<EmployeeManager>(),
                    new ValidateEmployeeManagerExistSpec(401)
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.Null(mgr);
        }

        [Fact]
        public async Task ValidateDepartmentExistSpec_ValidID_ShouldReturnNotNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT            
            var department = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<Department>(),
                    new ValidateDepartmentExistSpec(1)
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.NotNull(department);
        }

        [Fact]
        public async Task ValidateDepartmentExistSpec_InvalidID_ShouldReturnNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT            
            var department = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<Department>(),
                    new ValidateDepartmentExistSpec(100)
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.Null(department);
        }

        [Fact]
        public async Task ValidateShiftExistSpec_ValidID_ShouldReturnNotNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT            
            var shift = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<Shift>(),
                    new ValidateShiftExistSpec(1)
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.NotNull(shift);
        }

        [Fact]
        public async Task ValidateShiftExistSpec_InvalidID_ShouldReturnNull()
        {
            //SETUP
            CancellationToken cancellationToken = default;

            //ATTEMPT            
            var shift = await
                SpecificationEvaluator.Default.GetQuery
                (
                    _dbContext.Set<Shift>(),
                    new ValidateShiftExistSpec(100)
                ).FirstOrDefaultAsync(cancellationToken);

            //VERIFY
            Assert.Null(shift);
        }





    }
}