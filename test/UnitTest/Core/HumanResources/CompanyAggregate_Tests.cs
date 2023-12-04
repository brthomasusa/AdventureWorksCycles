using AWC.Core.Entities.HumanResources;
using AWC.Core.Entities.HumanResources.EntityIDs;
using AWC.SharedKernel.Base;
using AWC.UnitTest.Shared.Data;

namespace AWC.UnitTest.Core.UnitTests.HumanResources
{
    public class CompanyAggregate_Tests
    {
        private readonly Company _validCompany = CampanyTestData.CompanyResultWithValidData().Value;

        [Fact]
        private void CompanyID_Create_Should_Succeed()
        {
            // Arrange

            // Act
            CompanyID companyID = new(1);

            // Assert
            Assert.Equal(1, companyID.Value);
        }

        [Fact]
        private void ShiftID_Create_Should_Succeed()
        {
            // Arrange

            // Act
            ShiftID shiftID = new(1);

            // Assert
            Assert.Equal(1, shiftID.Value);
        }

        [Fact]
        private void DepartmentID_Create_Should_Succeed()
        {
            // Arrange

            // Act
            DepartmentID departmentID = new(1);

            // Assert
            Assert.Equal(1, departmentID.Value);
        }

        [Fact]
        public void Shift_Create_ValidData_ShouldReturn_Success()
        {
            // Arrange

            // Act
            Result<Shift> shiftResult = Shift.Create(new ShiftID(1), "AM Shift", 7, 0, 15, 0);

            // Assert
            Assert.True(shiftResult.IsSuccess);
        }

        [Fact]
        public void Shift_Create_InvalidData_StartHour_ShouldReturn_Failure()
        {
            // Arrange

            // Act
            Result<Shift> shiftResult = Shift.Create(new ShiftID(1), "AM Shift", 24, 0, 15, 0);

            // Assert
            Assert.True(shiftResult.IsFailure);
        }

        [Fact]
        public void Shift_Update_ValidData_ShouldReturn_Success()
        {
            // Arrange
            Result<Shift> createResult = Shift.Create(new ShiftID(1), "AM Shift", 7, 0, 15, 0);

            // Act
            Result<Shift> updateResult = createResult.Value.Update("PM Shift", 15, 0, 23, 0);

            // Assert
            Assert.True(updateResult.IsSuccess);
        }

        [Fact]
        public void Shift_Update_InvalidData_StartHour_ShouldReturn_Failure()
        {
            // Arrange
            Result<Shift> createResult = Shift.Create(new ShiftID(1), "AM Shift", 7, 0, 15, 0);

            // Act
            Result<Shift> updateResult = createResult.Value.Update("PM Shift", 24, 0, 8, 0);

            // Assert
            Assert.True(updateResult.IsFailure);
        }

        [Fact]
        public void Department_Create_ValidData_ShouldReturn_Success()
        {
            // Arrange

            // Act
            Result<Department> result = Department.Create(new DepartmentID(0), "Management", "Management Group");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Department_Create_InvalidData_NullName_ShouldReturn_Failure()
        {
            // Arrange

            // Act
            Result<Department> result = Department.Create(new DepartmentID(0), null!, "Management Group");

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Department_Create_InvalidData_NullGroupName_ShouldReturn_Failure()
        {
            // Arrange

            // Act
            Result<Department> result = Department.Create(new DepartmentID(0), "Management", null!);

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Department_Update_ValidData_ShouldReturn_Success()
        {
            // Arrange
            Result<Department> result = Department.Create(new DepartmentID(0), "Management", "Management Group");
            Department department = result.Value;

            // Act
            Result<Department> updateResult = department.Update("Management", "Management Group");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Department_Update_InvalidData_NullName_ShouldReturn_Failure()
        {
            // Arrange
            Result<Department> result = Department.Create(new DepartmentID(0), "Management", "Management Group");
            Department department = result.Value;

            // Act
            Result<Department> updateResult = department.Update(null!, "Management Group");

            // Assert
            Assert.True(updateResult.IsFailure);
        }

        [Fact]
        public void Department_Update_InvalidData_NullGroupName_ShouldReturn_Failure()
        {
            // Arrange
            Result<Department> result = Department.Create(new DepartmentID(0), "Management", "Management Group");
            Department department = result.Value;

            // Act
            Result<Department> updateResult = department.Update(null!, "Management Group");

            // Assert
            Assert.True(updateResult.IsFailure);
        }

        [Fact]
        public void Company_Create_ValidData_ShouldReturn_Success()
        {
            Result<Company> result = CampanyTestData.CompanyResultWithValidData();

            Assert.True(result.IsSuccess);
        }

        [Theory]
        [InlineData(null, "123456789", "123 Main St", "Somewhereville", 73, "77777")]
        [InlineData("IBM", "1234", "123 Main St", "Somewhereville", 73, "77777")]
        [InlineData("IBM", "123456789", null, "Somewhereville", 73, "77777")]
        [InlineData("IBM", "123456789", "123 Main St", null, 73, "77777")]
        [InlineData("IBM", "123456789", "123 Main St", "Somewhereville", 0, "77777")]
        [InlineData("IBM", "123456789", "123 Main St", "Somewhereville", 73, null)]
        public void Company_Create_InvalidData_ShouldReturn_Failure(string companyName, string ein, string line1, string city, int state, string postalCode)
        {
            // Arrange

            // Act
            Result<Company> result = Company.Create
            (
                new CompanyID(0),
                companyName,
                "Test Company",
                ein,
                "https://www.testcompany.com",
                line1,
                "Suite 10",
                city,
                state,
                postalCode,
                "123 Main Street",
                "Suite 10",
                "Austin",
                73,
                "78123",
                "512-555-5555",
                "512-555-9999"
            );

            // Assert
            Assert.True(result.IsFailure);
        }

        [Theory]
        [InlineData(null, "123456789", "123 Main St", "Somewhereville", 73, "77777")]
        [InlineData("IBM", "1234", "123 Main St", "Somewhereville", 73, "77777")]
        [InlineData("IBM", "123456789", null, "Somewhereville", 73, "77777")]
        [InlineData("IBM", "123456789", "123 Main St", null, 73, "77777")]
        [InlineData("IBM", "123456789", "123 Main St", "Somewhereville", 0, "77777")]
        [InlineData("IBM", "123456789", "123 Main St", "Somewhereville", 73, null)]
        public void Company_Update_ValidData_ShouldReturn_Success(string companyName, string ein, string line1, string city, int state, string postalCode)
        {
            // Arrange
            Result<Company> result = CampanyTestData.CompanyResultWithValidData();
            Company company = result.Value;

            // Act
            result = company.Update
            (
                companyName,
                "Test Company",
                ein,
                "https://www.testcompany.com",
                line1,
                "Suite 10",
                city,
                state,
                postalCode,
                "10 Sonarqube Highway",
                "Suite 10",
                "Sonar",
                79,
                "12345",
                "555-555-5555",
                "555-555-9999"
            );

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_Update_InvalidData_ShouldReturn_Failure()
        {
            // Arrange
            Result<Company> result = CampanyTestData.CompanyResultWithValidData();
            Company company = result.Value;

            // Act
            result = company.Update
            (
                "Sonarqube",
                "Test Company",
                "987654321",
                "https://www.testcompany.com",
                "10 Sonarqube Highway",
                "Suite 10",
                "Sonar",
                79,
                "12345",
                "10 Sonarqube Highway",
                "Suite 10",
                "Sonar",
                79,
                "12345",
                "555-555-5555",
                "555-555-9999"
            );

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Company_AddShift_ValidData_ShouldReturn_Success()
        {
            // Arrange

            // Act
            Result result = _validCompany.AddShift(new ShiftID(0), "Morning Shift", 7, 0, 15, 0);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Company_AddShift_ValidData_DupeZeroID_ShouldReturn_Success()
        {
            // Arrange
            _validCompany.AddShift(new ShiftID(0), "Morning Shift", 7, 0, 15, 0);

            // Act
            Result result = _validCompany.AddShift(new ShiftID(0), "Afternoon Shift", 15, 0, 23, 0);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Company_AddShift_InvalidData_DupeNonZeroID_ShouldReturn_Failure()
        {
            // Arrange
            _validCompany.AddShift(new ShiftID(1), "Morning Shift", 7, 0, 15, 0);

            // Act
            Result result = _validCompany.AddShift(new ShiftID(1), "Morning Shift", 7, 0, 15, 0);

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_AddShift_InvalidData_DupeShiftName_ShouldReturn_Failure()
        {
            // Arrange
            _validCompany.AddShift(new ShiftID(1), "Morning Shift", 7, 0, 15, 0);

            // Act
            Result result = _validCompany.AddShift(new ShiftID(0), "Morning Shift", 7, 30, 15, 30);

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_AddShift_InvalidData_DupeStartAndEndTime_ShouldReturn_Failure()
        {
            // Arrange
            _validCompany.AddShift(new ShiftID(1), "Morning Shift", 7, 0, 15, 0);

            // Act
            Result result = _validCompany.AddShift(new ShiftID(0), "Nigh Shift", 7, 0, 15, 0);

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_UpdateShift_ValidData_ShouldReturn_Success()
        {
            // Arrange
            Result result = _validCompany.AddShift(new ShiftID(1), "Nigh Shift", 7, 0, 15, 0);

            // Act
            result = _validCompany.UpdateShift(new ShiftID(1), "Night Shift", 7, 30, 15, 30);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Company_UpdateShift_InvalidData_InvalidID_ShouldReturn_Failure()
        {
            // Arrange
            Result result = _validCompany.AddShift(new ShiftID(1), "Night Shift", 23, 0, 7, 0);

            // Act
            result = _validCompany.UpdateShift(new ShiftID(12), "Night Shift", 7, 30, 15, 30);

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_UpdateShift_InvalidData_DupeShiftName_ShouldReturn_Failure()
        {
            // Arrange
            Result result = _validCompany.AddShift(new ShiftID(1), "Night Shift", 23, 0, 7, 0);

            // Act
            result = _validCompany.UpdateShift(new ShiftID(2), "Night Shift", 7, 30, 15, 30);

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_UpdateShift_InvalidData_DupeStartAndEndTimes_ShouldReturn_Failure()
        {
            // Arrange
            Result result = _validCompany.AddShift(new ShiftID(1), "Night Shift", 23, 0, 7, 0);

            // Act
            result = _validCompany.UpdateShift(new ShiftID(2), "Shift", 23, 0, 7, 0);

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_DeleteShift_ValidID_ShouldReturn_Success()
        {
            // Arrange
            Result result = _validCompany.AddShift(new ShiftID(1), "Nigh Shift", 7, 0, 15, 0);
            List<Shift> shifts = new(_validCompany.Shifts);
            Shift? shift = shifts.Find(s => s.Id.Value == 1);

            // Act
            result = _validCompany.DeleteShift(new ShiftID(1));

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(EntityStatus.Deleted, shift!.EntityStatus);
        }

        [Fact]
        public void Company_DeleteShift_InvalidID_ShouldReturn_Failure()
        {
            // Arrange
            Result result = _validCompany.AddShift(new ShiftID(1), "Nigh Shift", 7, 0, 15, 0);

            // Act
            result = _validCompany.DeleteShift(new ShiftID(11));

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_AddDepartment_ValidData_ShouldReturn_Success()
        {
            // Arrange

            // Act
            Result result = _validCompany.AddDepartment(new DepartmentID(0), "Department", "Department Group");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Company_AddDepartment_InvalidData_DupeZeroID_ShouldReturn_Success()
        {
            // Arrange
            Result result = _validCompany.AddDepartment(new DepartmentID(0), "Department One", "Department Group");

            // Act
            result = _validCompany.AddDepartment(new DepartmentID(0), "Department Two", "Department Group");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Company_AddDepartment_InvalidData_DupeNonZeroID_ShouldReturn_Failure()
        {
            // Arrange
            Result result = _validCompany.AddDepartment(new DepartmentID(1), "Department One", "Department Group");

            // Act
            result = _validCompany.AddDepartment(new DepartmentID(1), "Department Two", "Department Group");

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_AddDepartment_InvalidData_DupeDeptName_ShouldReturn_Failure()
        {
            // Arrange
            Result result = _validCompany.AddDepartment(new DepartmentID(1), "Department One", "Department Group");

            // Act
            result = _validCompany.AddDepartment(new DepartmentID(2), "Department One", "Department Group");

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_UpdateDepartment_ValidData_ShouldReturn_Success()
        {
            // Arrange
            Result result = _validCompany.AddDepartment(new DepartmentID(1), "Department One", "Department Group");

            // Act
            result = _validCompany.UpdateDepartment(new DepartmentID(1), "Department Zero", "Department Group");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Company_UpdateDepartment_InvalidData_DupeName_ShouldReturn_Failure()
        {
            // Arrange
            Result result = _validCompany.AddDepartment(new DepartmentID(1), "Department One", "Department Group");
            result = _validCompany.AddDepartment(new DepartmentID(2), "Department Two", "Department Group");

            // Act
            result = _validCompany.UpdateDepartment(new DepartmentID(2), "Department One", "Department Group");

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_UpdateDepartment_InvalidData_IdNotFound_ShouldReturn_Failure()
        {
            // Arrange
            Result result = _validCompany.AddDepartment(new DepartmentID(1), "Department One", "Department Group");

            // Act
            result = _validCompany.UpdateDepartment(new DepartmentID(11), "Department Zero", "Department Group");

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public void Company_DeleteDepartment_ValidID_ShouldReturn_Success()
        {
            // Arrange
            Result result = _validCompany.AddDepartment(new DepartmentID(1), "Department One", "Department Group");
            List<Department> departments = new(_validCompany.Departments);
            Department? department = departments.Find(d => d.Id.Value == 1);

            // Act
            result = _validCompany.DeleteDepartment(new DepartmentID(1));

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(EntityStatus.Deleted, department!.EntityStatus);
        }

        [Fact]
        public void Company_DeleteDepartment_InvalidID_ShouldReturn_Failure()
        {
            // Arrange
            Result result = _validCompany.AddDepartment(new DepartmentID(1), "Department One", "Department Group");

            // Act
            result = _validCompany.DeleteDepartment(new DepartmentID(11));

            // Assert
            Assert.True(result.IsFailure);
        }











    }
}