namespace Creating.From.Api.IntegrationTests
{
    using System.IO;
    using System.Net.Http;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;

    public static class TestServerConfig
    {
        public static HttpClient GetClient()
        {
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../Creating.From.Api/"));

            var builder = new WebHostBuilder()
           .UseContentRoot(basePath)
           .UseEnvironment("Development")
           .UseStartup<Startup>()
           ;

            TestServer testServer = new TestServer(builder);

            HttpClient client = testServer.CreateClient();
            return client;
        }
    }
}
