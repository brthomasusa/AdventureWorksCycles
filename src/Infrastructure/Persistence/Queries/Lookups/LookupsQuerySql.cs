namespace AWC.Infrastructure.Persistence.Queries.Lookups
{
    public static class LookupsQuerySql
    {
        public const string GetStateCodeIdForUSA =
        @"SELECT 
            StateProvinceID, LTRIM(RTRIM(StateProvinceCode)) AS StateProvinceCode
        FROM Person.StateProvince 
        WHERE CountryRegionCode = 'US' 
        ORDER BY StateProvinceCode";

        public const string GetStateCodeIdForAll =
        @"SELECT 
            StateProvinceID, LTRIM(RTRIM(StateProvinceCode)) AS StateProvinceCode 
        FROM Person.StateProvince 
        ORDER BY StateProvinceCode";

        public const string GetCountryCodes =
        @"SELECT 
            CountryRegionCode, [Name] 
        FROM Person.CountryRegion 
        ORDER BY [Name]";

        public const string GetDepartmentIds =
        @"SELECT 
            DepartmentID, LTRIM(RTRIM([Name])) AS DepartmentName 
        FROM HumanResources.Department 
        ORDER BY [Name]";

        public const string GetShiftIds =
        @"SELECT 
            ShiftID, LTRIM(RTRIM([Name])) AS ShiftName 
        FROM HumanResources.Shift 
        ORDER BY [Name]";

        public const string GetManagerIds =
        @"SELECT 
            BusinessEntityID, DepartmentID, DepartmentName, JobTitle, ManagerFullName 
        FROM HumanResources.vGetManagers 
        ORDER BY ManagerFullName";
    }
}
