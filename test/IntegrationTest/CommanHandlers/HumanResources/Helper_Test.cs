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