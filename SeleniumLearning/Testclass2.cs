using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    [TestFixture]
    internal class Testclass2
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {

            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            //driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver = new EdgeDriver();
            // for firefox driver use geckodriver.exe   
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Test()
        {
            driver.Url = "https://www.facebook.com/";
            TestContext.Progress.WriteLine(driver.Url);
            TestContext.Progress.WriteLine(driver.Title);
            //driver.PageSource
            driver.Close(); // To close 1 window
            //driver.Quit(); To close all windows opened
        }
    }
}
