using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace EndToEndFramework.pageObjects
{
    public class ProductPage
    {
        IWebDriver driver;
        private By cardTitle = By.CssSelector(".card-title a");
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        // IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;
        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public void waitForPageDisplay()
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public By getCardTitle()
        {
            return cardTitle;
        }
    }
}
