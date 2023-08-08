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
using EndToEndFramework.utilities;
using EndToEndFramework.pageObjects;
using SeleniumExtras.WaitHelpers;

namespace EndToEndFramework.tests
{
    internal class E2ETest : Base
    {

        [Test]
        public void EndtoEndFlow()
        {
            string[] expected_products = { "iphone X", "Blackberry" };
            string[] retrieved_products = new string[2];
            string successtext = "Success";
            LoginPage loginPage = new LoginPage(getDriver());
            ProductPage productPage = loginPage.validLogin("rahulshettyacademy", "learning");
            productPage.waitForPageDisplay();

         
            IList<IWebElement> products = productPage.getCards();
            foreach (IWebElement product in products)
            {
                if (expected_products.Contains(product.FindElement(productPage.getCardTitle()).Text))
                {
                    //click on cart
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            IList<IWebElement> actualCards = driver.FindElements(By.CssSelector("h4 a"));
            for (int i = 0; i < actualCards.Count; i++)
            {
                retrieved_products[i] = actualCards[i].Text;
            }
            Assert.AreEqual(expected_products, retrieved_products);
            driver.FindElement(By.ClassName("btn-success")).Click();

            driver.FindElement(By.Id("country")).SendKeys("ind");
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("India")));

            driver.FindElement(By.LinkText("India")).Click();
            driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
            driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();
            string actualText = driver.FindElement(By.ClassName("alert-success")).Text;

            StringAssert.Contains(successtext, actualText);
        }
    }
}
