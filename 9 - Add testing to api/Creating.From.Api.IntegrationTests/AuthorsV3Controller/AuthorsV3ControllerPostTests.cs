using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using Creating.From.Context.Entities;
using Creating.From.Api.Models;
using System.Net;

namespace Creating.From.Api.IntegrationTests.AuthorsV3Controller
{
    [Collection("Sequential")]
    public class AuthorsV3ControllerPostTests
    {
        private readonly HttpClient _client;

        public AuthorsV3ControllerPostTests()
        {
            this._client = TestServerConfig.GetClient();
        }
        [Fact]
        public async Task Create_Authors()
        {
            var authorToCreate = new AuthorCreateDto()
            {
                Name = "this is a random name"
            };

            HttpResponseMessage response = await this._client.PostAsJsonAsync("/Api/AuthorsV3", authorToCreate);

            // Fail the test if non-success result
            response.EnsureSuccessStatusCode();

            // Get the response as a string
            var author = await response.Content.ReadAsAsync<Author>();

            // Assert on correct content
            Assert.NotNull(author);
        }

        [Fact]
        public async Task Create_Author_With_Empty_Name()
        {
            var authorToCreate = new AuthorCreateDto()
            {
                Name = string.Empty
            };

            HttpResponseMessage response = await this._client.PostAsJsonAsync("/Api/AuthorsV3", authorToCreate);

            // Fail the test if non-success result

            // Get the response as a string

            // Assert on correct content
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task Create_Authors_And_Get()
        {
            var authorToCreate = new AuthorCreateDto()
            {
                Name = "Joe"
            };

            HttpResponseMessage response = await this._client.PostAsJsonAsync("/Api/AuthorsV3", authorToCreate);

            // Fail the test if non-success result
            response.EnsureSuccessStatusCode();

            // Get the response as a string
            var authorCreated = await response.Content.ReadAsAsync<Author>();

            // Assert on correct content
            Assert.NotNull(authorCreated);

            HttpResponseMessage responseGet = await this._client.GetAsync($"/Api/AuthorsV3/{authorCreated.Id}");
            // Fail the test if non-success result
            responseGet.EnsureSuccessStatusCode();

            // Get the response as a string
            var author = await responseGet.Content.ReadAsAsync<Author>();

            // Assert on correct content
            Assert.NotNull(author);
            Assert.Equal(authorToCreate.Name, author.Name);
        }
    }
}
