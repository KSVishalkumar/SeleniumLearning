using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    internal class Locators
    {
        // Xpath, css, id, classname, name, tagname, linktext

        // below line is to set the driver variable in global level

        IWebDriver driver;  
        [SetUp]
        public void StartBrowser()
        {
            // The below line is used to get the .exe file of which browser we are going to work on
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            
            
            // Implicit wait 5sec will be declared globally
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        [Test]
        public void LocatorsIdentification()
        {
            driver.FindElement(By.Id("username")).SendKeys("70956705");
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("ksvishal4848@gmail.com");
            driver.FindElement(By.Name("password")).SendKeys("Ksvk@#32");
           
            //driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            // for cssselector use   tagname[attribute ='value']

            // For xpathselector use   //tagname[@attribute='value']
            // CSS  - .text-info span:nth-child(1) input
            // xpath - //label[@class='text-info']/span/input
            // id - in CSS - #id

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            
            // Thread.Sleep(3000); // Hard sleep  
            
            //Explicit wait
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.FindElement(By.XPath("//input[@name='signin']")),"Sign In"));
            
            
            String errorMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            
            // in NUnit framework to see the output we use the below code
            TestContext.Progress.WriteLine(errorMessage);

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttr = link.GetAttribute("href");

            //Assertion - checking the expected value is equal to the value that We get 
            // If condition is true the test passes if false it fails 

            String expectedUrl = "https://rahulshettyacademy.com/documents-request";
            Assert.That(hrefAttr, Is.EqualTo(expectedUrl));
            driver.Close();
        }
    }
}
