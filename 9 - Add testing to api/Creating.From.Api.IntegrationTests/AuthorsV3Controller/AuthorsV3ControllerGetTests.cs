using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Creating.From.Context.Entities;
using System.Linq;

namespace Creating.From.Api.IntegrationTests.AuthorsV3Controller
{
    [Collection("Sequential")]
    public class AuthorsV3ControllerGetTests
    {
        [Fact]
        public async Task Get_Authors()
        {
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Creating.From.Api/"));

            var builder = new WebHostBuilder()
               .UseContentRoot(basePath)
               .UseEnvironment("Development")
               .UseStartup<Startup>()
           ;

            TestServer testServer = new TestServer(builder);

            HttpClient client = testServer.CreateClient();

            HttpResponseMessage response = await client.GetAsync("/Api/AuthorsV3");

            // Fail the test if non-success result
            response.EnsureSuccessStatusCode();

            // Get the response as a string
            var authors = await response.Content.ReadAsAsync<IEnumerable<Author>>();

            // Assert on correct content
            Assert.True(authors.Any());
        }
    }
}
