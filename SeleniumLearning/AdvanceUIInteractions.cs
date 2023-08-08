using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace SeleniumLearning
{
    internal class AdvanceUIInteractions
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            // driver = new ChromeDriver();
            EdgeOptions options = new EdgeOptions();

            // Enable incognito mode
            options.AddArgument("--inprivate");

            // Create the WebDriver instance
            driver = new EdgeDriver(options);

            driver.Manage().Window.Maximize();

            
        }
        [Test]
        public void HoverMouseonElement()
        {
            driver.Url = "https://rahulshettyacademy.com";
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            Thread.Sleep(3000);
            a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();
        }
        [Test]
        public void DragDropElement()
        {
            driver.Url = "https://demoqa.com/droppable";
            Actions a = new Actions(driver);
            a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();

        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
