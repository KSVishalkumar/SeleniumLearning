using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.DevTools.V112.Debugger;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace EndToEndFramework.utilities
{
    internal class Base
    {
        public IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            //InitBrowser("Chrome");
            string browserName = ConfigurationManager.AppSettings["browser"];

            InitBrowser(browserName);

            //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            //driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        public IWebDriver getDriver()
        {
            return driver;
        }
        public void InitBrowser(string browserName)
        {
            // Factory Design Pattern
            switch (browserName)
            {
                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
                case null:
                    TestContext.Progress.WriteLine("Select only Chrome or Edge");
                    break;
            }
        }
        [TearDown]
        public void StopBrowser()
        {
            driver.Quit();
        }
    }
}
