using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Metadata.Ecma335;

namespace SeleniumLearning
{
    internal class E2ETest
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {

            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void EndtoEndFlow()
        {
            String[] expected_products = { "iphone X", "Blackberry" };
            String[] retrieved_products = new string[2];
            String successtext = "Success";
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach(IWebElement product in products)
            {
               if(expected_products.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    //click on cart
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }                
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            IList <IWebElement> actualCards= driver.FindElements(By.CssSelector("h4 a"));
            for(int i= 0; i < actualCards.Count; i++)
            {
                retrieved_products[i] = actualCards[i].Text;
            }
            Assert.AreEqual(expected_products, retrieved_products);
            driver.FindElement(By.ClassName("btn-success")).Click() ;

            driver.FindElement(By.Id("country")).SendKeys("ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));

            driver.FindElement(By.LinkText("India")).Click();
            driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
            driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();
            String actualText = driver.FindElement(By.ClassName("alert-success")).Text;

            StringAssert.Contains(successtext, actualText);
        }
    }
}
