using AWC.Application.Features.HumanResources.Common;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Interfaces.Messaging;
using AWC.Core.HumanResources;
using AWC.Core.Shared;
using AWC.Infrastructure.Persistence.Interfaces;
using AWC.SharedKernel.Utilities;
using AWC.IntegrationTests.Base;

namespace AWC.IntegrationTest.CommanHandlers.HumanResources
{
    public class Helper_Test
    {
        [Fact]
        public void Dunno()
        {
            object createEmployee = EmployeeTestData.GetValidCreateEmployeeCommand();
            string className = createEmployee.GetType().Name;
            Assert.NotNull(className);
        }
    }
}