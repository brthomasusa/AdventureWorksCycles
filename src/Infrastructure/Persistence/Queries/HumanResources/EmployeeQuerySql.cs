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

    }
}