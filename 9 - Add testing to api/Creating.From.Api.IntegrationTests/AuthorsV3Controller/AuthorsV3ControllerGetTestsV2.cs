using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using Creating.From.Context.Entities;
using System.Linq;

namespace Creating.From.Api.IntegrationTests.AuthorsV3Controller
{
    [Collection("Sequential")]
    public class AuthorsV3ControllerGetTestsV2
    {
        private readonly HttpClient _client;

        public AuthorsV3ControllerGetTestsV2()
        {
            this._client = TestServerConfig.GetClient();
        }
        [Fact]
        public async Task Get_Authors()
        {
            HttpResponseMessage response = await this._client.GetAsync("/Api/AuthorsV3");

            // Fail the test if non-success result
            response.EnsureSuccessStatusCode();

            // Get the response as a string
            var authors = await response.Content.ReadAsAsync<IEnumerable<Author>>();

            // Assert on correct content
            Assert.True(authors.Any());
        }
    }
}
