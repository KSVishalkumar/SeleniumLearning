using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndToEndFramework.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            
        }
        // driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
        //driver.FindElement(By.Id("password")).SendKeys("learning");
        //driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        //river.FindElement(By.XPath("//input[@type='submit']")).Click();

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;  // Encapsulation
        [FindsBy(How = How.Name,Using = "password")]
        private IWebElement password;
        [FindsBy(How = How.XPath, Using = "//input[@id='terms']")]
        private IWebElement checkbox;
        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submit;

        public IWebElement getUserName()
        {
            return username;
        }
        public IWebElement getPassword()
        {
            return password;
        }
        public IWebElement getCheckbox()
        {
            return checkbox;
        }
        public IWebElement getSubmit()
        {
            return submit;
        }

        public ProductPage validLogin(String user, String pass)
        {
            getUserName().SendKeys(user);
            getPassword().SendKeys(pass);
            getCheckbox().Click();
            getSubmit().Click();
            return new ProductPage(driver);
        }
    }
}
