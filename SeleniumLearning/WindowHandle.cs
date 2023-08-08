using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumLearning
{
    internal class WindowHandle
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            
            EdgeOptions options = new EdgeOptions();
                       
            options.AddArgument("--inprivate");

            driver = new EdgeDriver(options);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void Window()
        {
            String parentWindow = driver.CurrentWindowHandle;
            String email = "mentor@rahulshettyacademy.com";
            driver.FindElement(By.CssSelector(".blinkingText")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);

            String ChildWindow = driver.WindowHandles[1];

            driver.SwitchTo().Window(ChildWindow);

            TestContext.Progress.WriteLine(driver.FindElement(By.XPath("//p[@class='im-para red']")).Text);
            String text = driver.FindElement(By.XPath("//p[@class='im-para red']")).Text;

            //Please email us at mentor@rahulshettyacademy.com with below template to receive response

            String[] splittedText = text.Split("at");

            String[] trimmedText = splittedText[1].Trim().Split(" ");

            Assert.AreEqual(email, trimmedText[0]);

            TestContext.Progress.WriteLine(trimmedText[0]);

            driver.SwitchTo().Window(parentWindow);
            driver.FindElement(By.Name("username")).SendKeys(trimmedText[0]);
        }
        [TearDown]
        public void StopBrowser()
        {
           driver.Quit();
        }
    }
}
