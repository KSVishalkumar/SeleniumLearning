using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace SeleniumLearning
{
    internal class SortingWebTable
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }
        [Test]
        public void SortTable()
        {
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));

            dropdown.SelectByText("20");

            // Algorithm
            // 1 - Get all veggie names in an array list - A
            ArrayList a = new ArrayList();
            IList<IWebElement> BeforeSorting = driver.FindElements(By.XPath("//tr/td[1]"));

                // To get the text from the elements
            foreach( IWebElement before in BeforeSorting)
            {
                a.Add(before.Text);
            }
            a.Sort();
            foreach(string veggies in a)
            {
                Console.WriteLine(veggies);
            }
            // 2 - Click on the column to sort the veggie names
            // CSS - th[aria-label*='Veg/fruit name']
            // Xpath - //th[@contains(aria-label, 'fruit name')]
            driver.FindElement(By.CssSelector("th[aria-label*='Veg/fruit name']")).Click(); 
            // 3 - Collect all the sorted veggie names in another array list - B

            ArrayList b = new ArrayList();
            IList<IWebElement> AfterSorting = driver.FindElements(By.XPath("//tr/td[1]"));

            // To get the text from the elements
            foreach (IWebElement before in AfterSorting)
            {
                b.Add(before.Text);
            }
            foreach (string veggies in b)
            {
                Console.WriteLine(veggies);
            }

            // 4 - Compare both the arraylist
            Assert.That(b, Is.EqualTo(a));
        }
    }
}
