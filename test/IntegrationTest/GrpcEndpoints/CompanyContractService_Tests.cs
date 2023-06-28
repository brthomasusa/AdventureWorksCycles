#pragma warning disable CS8600, CS8602

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using AWC.Application.Features.HumanResources.UpdateCompany;
using AWC.IntegrationTests.Base;
using AWC.Shared.Queries.HumanResources;
using Microsoft.AspNetCore.WebUtilities;

namespace AWC.IntegrationTest.GrpcEndpoints
{
    public class CompanyContractService_Tests : IntegrationTestBase
    {
        public CompanyContractService_Tests(ApiWebApplicationFactory fixture) : base(fixture)
        { }
    }
}