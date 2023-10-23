#pragma warning disable CS8600, CS8602

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using AWC.Application.Features.HumanResources.CreateEmployee;
using AWC.Application.Features.HumanResources.DeleteEmployee;
using AWC.Application.Features.HumanResources.UpdateEmployee;
using AWC.Shared.Queries.HumanResources;
using Microsoft.AspNetCore.WebUtilities;

namespace AWC.IntegrationTest.HumanResources.ApiEndPoint_Tests
{
    [Collection("Database Test")]
    public class EmployeeEndPoint_Tests : IntegrationTestBase
    {
        public EmployeeEndPoint_Tests(ApiWebApplicationFactory fixture) : base(fixture)
        { }

        [Fact]
        public async Task Employee_GetEmployeeDetails_ShouldSucceed()
        {
            const int employeeId = 1;
            using var response = await _client.GetAsync($"{_urlRoot}employees/details/{employeeId}",
                                                        HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var employee = await JsonSerializer.DeserializeAsync<EmployeeDetails>(jsonResponse, _options);

            Assert.Equal("Ken", employee.FirstName);
            Assert.Equal("Sánchez", employee.LastName);
        }

        [Fact]
        public async Task Employee_GetEmployeeCommand_ShouldSucceed()
        {
            const int employeeId = 1;
            using var response = await _client.GetAsync($"{_urlRoot}employees/command/{employeeId}",
                                                        HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var employee = await JsonSerializer.DeserializeAsync<EmployeeGenericCommand>(jsonResponse, _options);

            Assert.Equal("Ken", employee.FirstName);
            Assert.Equal("Sánchez", employee.LastName);
        }

        [Fact]
        public async Task Employee_GetEmployeeListItemsFilterByLastName_ShouldSucceed()
        {
            var queryParams = new Dictionary<string, string?>
            {
                ["searchField"] = "LastName",
                ["searchCriteria"] = "Du",
                ["orderBy"] = "LastName",
                ["pageNumber"] = "0",
                ["pageSize"] = "0",
                ["skip"] = "0",
                ["take"] = "10"
            };


            List<EmployeeListItem> response = await _client
                .GetFromJsonAsync<List<EmployeeListItem>>(QueryHelpers.AddQueryString($"{_urlRoot}employees/filterbylastname", queryParams));

            Assert.Equal(4, response.Count);
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
            var employee = await JsonSerializer.DeserializeAsync<EmployeeDetails>(jsonResponse, _options);
            Assert.Equal("13232145", employee.NationalIDNumber);
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

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Employee_DeleteEmployeeInfo_Valid_ShouldSucceed()
        {
            string uri = $"{_urlRoot}employees/delete";
            DeleteEmployeeCommand command = new(BusinessEntityID: 4);

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
            DeleteEmployeeCommand command = new(BusinessEntityID: 2221);

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