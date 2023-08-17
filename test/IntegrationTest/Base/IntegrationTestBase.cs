using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using AWC.SharedKernel.Utilities;
using Xunit;

namespace AWC.IntegrationTests.Base
{
    [Trait("Category", "Integration")]
    public abstract class IntegrationTestBase : IClassFixture<ApiWebApplicationFactory>
    {
        protected readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;
        protected readonly string _urlRoot = "api/";
        protected readonly JsonSerializerOptions _options;

        protected IntegrationTestBase(ApiWebApplicationFactory fixture)
        {
            _factory = fixture;
            _client = _factory.CreateClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _ = ReseedTestDatabase.ReseedDatabase();
        }
    }
}