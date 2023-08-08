using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Xsl;

namespace SeleniumLearning
{
    [TestFixture]
    internal class AlertsActionsAutoSuggestive
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
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            
        }


        [Test]
        public void testAlert()
        {
            String name = "Vishal";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*=\"displayConfirm\"]")).Click();
            String alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            StringAssert.Contains(name, alertText);
        }

        [Test]
        public void AutoSuggestiveDropdown()
        {
            
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }
                TestContext.Progress.WriteLine(option.Text);
            }
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
        }
        [Test]
        public void SelectDropDown()
        {
            IWebElement dropdown1 = driver.FindElement(By.Id("dropdown-class-example"));

            SelectElement select = new SelectElement(dropdown1);

            select.SelectByText("Option2");
        }
        [Test]
        public void Frames()
        {
            // To scroll webpage
            // Create a variable to locate frames
            IWebElement frameElement = driver.FindElement(By.Id("courses-iframe"));
            // Javascript Executor code
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameElement);


            // To switch into frames
            // id, value, index
            // Switch to the first frame
            //driver.SwitchTo().Frame(0);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.SwitchTo().Frame(frameElement);
            IWebElement All = driver.FindElement(By.LinkText("All Access Plan"));
            All.Click();
            // Inside frame header
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
            driver.SwitchTo().DefaultContent();
            // Oustside frame header
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);

        }
        [TearDown]
        public void TearDown()
        {
           driver.Quit();
        }
    }
}

