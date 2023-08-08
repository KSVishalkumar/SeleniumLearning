using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class Tests
    {
        IWebDriver driver; 
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup Method");
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            TestContext.Progress.WriteLine("Test 1");
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");

            IWebElement dropdownelement = driver.FindElement(By.CssSelector("select.form-control"));

            SelectElement d = new SelectElement(dropdownelement);

            d.SelectByText("Teacher");
            d.SelectByValue("consult");

            IList <IWebElement> radios = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach(IWebElement radiobutton in radios)
            {
                if(radiobutton.GetAttribute("value").Equals("user"))
                {
                    radiobutton.Click();
                }
            }
            driver.FindElement(By.Id("okayBtn")).Click();


            //Thread.Sleep(5000);
            driver.FindElement(By.Id("signInBtn")).Click();
            //Thread.Sleep(5000);
        }
        
        [TearDown]
        public void TearDown() 
        {
            TestContext.Progress.WriteLine("Tear down");
            driver.Quit();
        }
    }
}