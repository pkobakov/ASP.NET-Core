namespace MyFirstweb.Tests
{
    using MyFirstWeb;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Xunit;
    public class SeleniumTests
    {
        [Fact]
        public void H1ElementIsRemovedFromPrivacyPage()
        {
            // Get server builder from Niki Kostov's ASP.Net Core Template

            var serverFactory = new SeleniumServerFactory<Startup>();

            // Chrome configuring
            var options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddArguments("--headless");

            var webDriver = new ChromeDriver(options);

            var indexUrl = serverFactory.RootUri;

            webDriver.Navigate().GoToUrl($"{indexUrl}/Home/Privacy");

            Assert.Throws<NoSuchElementException>(() => webDriver.FindElement(By.TagName("h1")));
        }
    }
}
