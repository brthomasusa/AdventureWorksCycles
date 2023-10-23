#pragma warning disable CS8600, CS8602

using System.Text.Json;
using AWC.Shared.Queries.Lookups.HumanResources;
using AWC.Shared.Queries.Lookups.Shared;

namespace AWC.IntegrationTest.Lookups.ApiEndPoint_Tests
{
    [Collection("Database Test")]
    public class LookupsEndPoint_Tests : IntegrationTestBase
    {
        public LookupsEndPoint_Tests(ApiWebApplicationFactory fixture) : base(fixture)
        { }

        [Fact]
        public async Task Lookups_GetStateCodeIdForAll_ShouldSucceed()
        {
            using var response = await _client.GetAsync($"{_urlRoot}lookups/statecodes/all",
                                                        HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var statecodes = await JsonSerializer.DeserializeAsync<List<StateCode>>(jsonResponse, _options);

            Assert.True(statecodes!.Any());
            Assert.Equal(181, statecodes.Count);
        }

        [Fact]
        public async Task Lookups_GetStateCodeIdForUSA_ShouldSucceed()
        {
            using var response = await _client.GetAsync($"{_urlRoot}lookups/statecodes/usa",
                                                        HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var statecodes = await JsonSerializer.DeserializeAsync<List<StateCode>>(jsonResponse, _options);

            Assert.True(statecodes!.Any());
            Assert.Equal(53, statecodes.Count);
        }

        [Fact]
        public async Task Lookups_GetCountryCodes_ShouldSucceed()
        {
            using var response = await _client.GetAsync($"{_urlRoot}lookups/countrycodes",
                                                        HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var countryCodes = await JsonSerializer.DeserializeAsync<List<CountryCode>>(jsonResponse, _options);

            Assert.True(countryCodes!.Any());
            Assert.Equal(238, countryCodes.Count);
        }

        [Fact]
        public async Task Lookups_GetDepartmentIds_ShouldSucceed()
        {
            using var response = await _client.GetAsync($"{_urlRoot}lookups/departmentids",
                                                        HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var departmentIds = await JsonSerializer.DeserializeAsync<List<DepartmentId>>(jsonResponse, _options);

            Assert.True(departmentIds!.Any());
        }

        [Fact]
        public async Task Lookups_GetShiftIds_ShouldSucceed()
        {
            using var response = await _client.GetAsync($"{_urlRoot}lookups/shiftids",
                                                        HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var shiftIds = await JsonSerializer.DeserializeAsync<List<ShiftId>>(jsonResponse, _options);

            Assert.True(shiftIds!.Any());
        }

        [Fact]
        public async Task Lookups_GetManagerIds_ShouldSucceed()
        {
            using var response = await _client.GetAsync($"{_urlRoot}lookups/managerids",
                                                        HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var managerIds = await JsonSerializer.DeserializeAsync<List<ManagerId>>(jsonResponse, _options);

            Assert.True(managerIds!.Any());
        }
    }
}