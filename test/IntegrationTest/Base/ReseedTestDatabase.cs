using System;
using System.Data.SqlClient;
using AWC.SharedKernel.Utilities;

namespace AWC.IntegrationTests.Base
{
    public static class ReseedTestDatabase
    {
        public static Result<bool> ReseedDatabase()
        {
            const string connectionString = "Server=tcp:mssql-server,1433;Database=AdventureWorks_Test;User Id=sa;Password=Info99Gum;MultipleActiveResultSets=true;TrustServerCertificate=true";

            try
            {
                using SqlConnection connection = new(connectionString);
                SqlCommand command = new("dbo.usp_InitializeTestDb", connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure<bool>(new Error("ReseedTestDatabase.ReseedTestDatabase", Helpers.GetExceptionMessage(ex)));
            }
        }
    }
}