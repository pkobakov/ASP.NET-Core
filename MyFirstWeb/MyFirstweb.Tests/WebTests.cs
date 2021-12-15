namespace MyFirstweb.Tests
{
    using Microsoft.AspNetCore.Mvc.Testing;
    using MyFirstWeb;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    public class WebTests
    {
        [Fact]
        public async Task HomePageShouldContainMyFirstWeb()
        {
            var webApplication = new WebApplicationFactory<Startup>();
            HttpClient client = webApplication.CreateClient();

            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains("MyFirstWeb",html);
        }

        [Fact]
        public async Task HomePageResponseShouldContainContentTypeHeader() 
        {
            var webApplication = new WebApplicationFactory<Startup>();
            HttpClient client = webApplication.CreateClient();

            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode(); 
            Assert.True(response.Headers.Contains("Set-Cookie"));
        }
    }
}
