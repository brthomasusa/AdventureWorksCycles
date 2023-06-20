#pragma warning disable CS8600, CS8602

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.DeleteEmployee;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Infrastructure.Persistence.Queries.HumanResources;
using AWC.Shared.Queries.HumanResources;
using Microsoft.AspNetCore.WebUtilities;

namespace AWC.IntegrationTests.ApiEndPoint_Tests
{
    public class EmployeeEndPoint_Tests : IntegrationTest
    {
        public EmployeeEndPoint_Tests(ApiWebApplicationFactory fixture) : base(fixture)
        { }

        [Fact]
        public async Task Employee_GetEmployeeDetailsByIdWithAllInfoQuery_ShouldSucceed()
        {
            const int employeeId = 1;
            using var response = await _client.GetAsync($"{_urlRoot}employees/allinfo/{employeeId}",
                                                        HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var employee = await JsonSerializer.DeserializeAsync<EmployeeDetailReadModel>(jsonResponse, _options);

            Assert.Equal("Ken", employee.FirstName);
            Assert.Equal("Sánchez", employee.LastName);
        }

        [Fact]
        public async Task Employee_GetEmployeeListItemsFilterByLastName_ShouldSucceed()
        {
            var pagingParams = new { PageNumber = 1, PageSize = 10 };
            const string lastName = "A";

            var queryParams = new Dictionary<string, string?>
            {
                ["pageNumber"] = pagingParams.PageNumber.ToString(),
                ["pageSize"] = pagingParams.PageSize.ToString(),
                ["lastName"] = lastName
            };

            List<EmployeeListItemReadModel> response = await _client
                .GetFromJsonAsync<List<EmployeeListItemReadModel>>(QueryHelpers.AddQueryString($"{_urlRoot}employees/filterbylastname", queryParams));

            Assert.Equal(10, response.Count);
        }

        [Fact]
        public async Task Employee_CreateEmployeeInfo_ValidData_ShouldSucceed()
        {
            string uri = $"{_urlRoot}employees/create";
            CreateEmployeeCommand command = EmployeeTestData.GetValidCreateEmployeeCommand();

            var memStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memStream, command);
            memStream.Seek(0, SeekOrigin.Begin);

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var requestContent = new StreamContent(memStream);
            request.Content = requestContent;
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var employeeResponse = await JsonSerializer.DeserializeAsync<GetEmployeeDetailByIdResponse>(jsonResponse, _options);
        }

        [Fact]
        public async Task Employee_CreateEmployeeInfo_InvalidData_DupeNationalIdShouldFail()
        {
            string uri = $"{_urlRoot}employees/create";
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_DupeNationalID();

            var memStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memStream, command);
            memStream.Seek(0, SeekOrigin.Begin);

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var requestContent = new StreamContent(memStream);
            request.Content = requestContent;
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task FluentValidation_CreateEmployeeInfo_InvalidData_ShouldFail()
        {
            string uri = $"{_urlRoot}employees/create";
            CreateEmployeeCommand command = EmployeeTestData.GetInvalidCreateEmployeeCommand_Under18();

            var memStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memStream, command);
            memStream.Seek(0, SeekOrigin.Begin);

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var requestContent = new StreamContent(memStream);
            request.Content = requestContent;
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Employee_UpdateEmployeeInfo_ValidData_ShouldSucceed()
        {
            string uri = $"{_urlRoot}employees/update";
            UpdateEmployeeCommand command = EmployeeTestData.GetUpdateEmployeeCommand_ValidData();

            var memStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memStream, command);
            memStream.Seek(0, SeekOrigin.Begin);

            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var requestContent = new StreamContent(memStream);
            request.Content = requestContent;
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Employee_DeleteEmployeeInfo_Valid_ShouldSucceed()
        {
            string uri = $"{_urlRoot}employees/delete";
            DeleteEmployeeCommand command = new(EmployeeID: 2);

            var memStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memStream, command);
            memStream.Seek(0, SeekOrigin.Begin);

            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var requestContent = new StreamContent(memStream);
            request.Content = requestContent;
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Employee_DeleteEmployeeInfo_InvalidEmployeeID_ShouldFail()
        {
            string uri = $"{_urlRoot}employees/delete";
            DeleteEmployeeCommand command = new(EmployeeID: 2221);

            var memStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(memStream, command);
            memStream.Seek(0, SeekOrigin.Begin);

            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var requestContent = new StreamContent(memStream);
            request.Content = requestContent;
            requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            Assert.False(response.IsSuccessStatusCode);
        }
    }
}