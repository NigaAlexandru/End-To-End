using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
   public class BasketPage
    {

       public BasketPage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//div[contains(text(), 'Cosul tau este gol')]")]
        public IWebElement emptyBasketMessage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), 'Sterge')]")]
        public IWebElement DeleteButton { get; set; }
    }
}
