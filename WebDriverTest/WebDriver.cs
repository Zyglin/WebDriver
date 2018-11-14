using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTest
{
    [TestFixture]
    public class WebDriver

    {

        [Test]
        public void Test_write_flight()
        {
            RemoteWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.turkishairlines.com/");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var btn = driver.FindElement(By.XPath("//a[@href='#bookerDeparTab']"));
            btn.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("membershipNumber"))).SendKeys("284");
            var findFlight = driver.FindElement(By.XPath("//a[@data-bind='click : findFlights']"));
            findFlight.Click();
            var statusFlight = driver.FindElement(By.XPath("//div[@class='h4 img-align-right']"));
            Assert.IsNotNull(statusFlight,"Here is no any data about flight");
		Assert.areEquals("284",statusFlight,"flight status is incorrect");
                   
        }
    }
}
