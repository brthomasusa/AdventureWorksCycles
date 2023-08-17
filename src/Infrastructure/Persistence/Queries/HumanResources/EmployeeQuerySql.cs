namespace AWC.Infrastructure.Persistence.Queries.HumanResources
{
    public static class EmployeeQuerySql
    {
        public const string GetEmployeeListItems =
        @"SELECT 
            BusinessEntityID           
            ,LastName
            ,FirstName
            ,MiddleName 
            ,JobTitle
            ,Department
            ,Shift
            ,PhoneNumber 
            ,EmailAddress
            ,Active
            ,FullName 
            ,ManagerID
            ,EmployeesManaged 
            ,ManagerName                       
        FROM HumanResources.vEmployeeListItems";

        public const string GetEmployeeListItemsCount =
        @"SELECT 
            COUNT(*)               
        FROM HumanResources.vEmployeeListItems";

        public const string GetEmployeeCommand =
            @"SELECT
                BusinessEntityID
                ,NameStyle
                ,Title
                ,FirstName
                ,MiddleName
                ,LastName
                ,Suffix
                ,JobTitle
                ,PhoneNumber
                ,PhoneNumberTypeID
                ,EmailAddress
                ,EmailPromotion
                ,NationalIDNumber
                ,LoginID
                ,AddressLine1
                ,AddressLine2
                ,City
                ,StateProvinceID
                ,PostalCode
                ,CountryRegionCode
                ,BirthDate
                ,MaritalStatus
                ,Gender
                ,HireDate
                ,Salaried
                ,VacationHours
                ,SickLeaveHours
                ,PayRate
                ,PayFrequency
                ,Active
                ,ManagerID
                ,DepartmentID
                ,ShiftID
            FROM HumanResources.tvfGetEmployeeCommand(@ID)";

        public const string GetEmployeeDetails =
            @"SELECT
                BusinessEntityID
                ,NameStyle  
                ,Title
                ,FirstName
                ,MiddleName
                ,LastName
                ,Suffix
                ,JobTitle  
                ,PhoneNumber
                ,PhoneNumberType
                ,EmailAddress
                ,EmailPromotion
                ,NationalIDNumber
                ,LoginID
                ,AddressLine1
                ,AddressLine2
                ,City
                ,StateProvinceName 
                ,PostalCode
                ,CountryRegionName
                ,BirthDate
                ,MaritalStatus
                ,Gender
                ,HireDate
                ,Salaried
                ,VacationHours
                ,SickLeaveHours
                ,PayRate
                ,PayFrequency
                ,Active
                ,ManagerName
                ,Department
                ,Shift
                ,Address
            FROM HumanResources.udfGetEmployeeDetails(@ID
            )";

        public const string GetDepartmentHistories =
            @"SELECT
                edh.BusinessEntityID
                ,dept.Name AS Department
                ,shift.Name AS Shift
                ,edh.StartDate
                ,edh.EndDate
            FROM HumanResources.EmployeeDepartmentHistory edh
            INNER JOIN HumanResources.Department dept ON edh.DepartmentID = dept.DepartmentID
            INNER JOIN HumanResources.Shift shift ON edh.ShiftID = shift.ShiftID
            WHERE edh.BusinessEntityID = @ID
            ORDER BY edh.StartDate";

        public const string GetDepartmentHistoryCommands =
            @"SELECT
                BusinessEntityID
                ,DepartmentID
                ,ShiftID
                ,StartDate
                ,EndDate
            FROM HumanResources.EmployeeDepartmentHistory
            WHERE BusinessEntityID = @ID
            ORDER BY StartDate";

        public const string GetPayHistories =
            @"SELECT
                BusinessEntityID
                ,RateChangeDate
                ,Rate
                ,CASE
                    WHEN PayFrequency = 1 THEN 'Monthly'
                    WHEN PayFrequency = 2 THEN 'Biweekly'     
                END AS PayFrequency     
            FROM HumanResources.EmployeePayHistory
            WHERE BusinessEntityID = @ID
            ORDER BY RateChangeDate";

        public const string GetPayHistoryCommands =
            @"SELECT
                BusinessEntityID
                ,RateChangeDate
                ,Rate
                ,PayFrequency
            FROM HumanResources.EmployeePayHistory
            WHERE BusinessEntityID = @ID
            ORDER BY RateChangeDate";

    }
}