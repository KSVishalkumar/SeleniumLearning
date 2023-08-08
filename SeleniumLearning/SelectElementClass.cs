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
    internal class SelectElementClass
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
        public void dropdown() 
        {
            // Drop Down List 

            IWebElement dropdown = driver.FindElement(By.CssSelector("select.form-control"));
            
            // SelectElement class is used to select option in dropdown list

            SelectElement s = new SelectElement(dropdown);
            s.SelectByIndex(0);
            s.SelectByValue("consult");
            s.SelectByText("Teacher");

            // Radio Buttons
            // To not give the index value in the css selector we use the below method

            IList<IWebElement> rdos = driver.FindElements(By.CssSelector("input[type='radio'"));

            foreach (IWebElement radioButton in rdos)
            {
                if (radioButton.GetAttribute("value").Equals("user"));
                {
                    radioButton.Click();
                }
            }

            // Explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
           
            // To see the radio button is selected or not

            // First click on the radio button
            driver.FindElement(By.Id("okayBtn")).Click();

            // Now get the result if clicked
            bool result = driver.FindElement(By.Id("usertype")).Selected;

            Assert.That(result, Is.True);

        }
    }
}
