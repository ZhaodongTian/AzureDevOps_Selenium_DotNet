using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace Demo.SeleniumTests
{
    [TestClass]
    public class DotNetSiteTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestGetStarted()
        {
            // Chrome Driver was manually downloaded from https://sites.google.com/a/chromium.org/chromedriver/downloads
            // parameter "." will instruct to look for the chromedriver.exe in the current folder (bin/debug/...)
            using (var driver = GetDriver())
            {
                //Navigate to DotNet website
                driver.Navigate().GoToUrl((string)TestContext.Properties["webAppUrl"]);
                //Click the Get Started button
                driver.FindElement(By.LinkText("Get started")).Click();               
                var lastStepTitle = driver.FindElement(By.Id("mainContent"));
                // verify the title is the expected value "Next steps"
               Assert.IsNotNull(lastStepTitle, "get null");
            }
        }

        private ChromeDriver GetDriver()
        {
            var options = new ChromeOptions();

            if (bool.Parse((string)TestContext.Properties["headless"]))
            {
                options.AddArgument("headless");
            }

            return new ChromeDriver(".", options);
        }
    }
}