using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework.Pages
{
    public class ProductPage
    {
        public ProductPage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div/button[contains(@class, 'yeahIWantThisProduct')]")]
        public IWebElement buyButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[contains(text(), 'Produsul a fost adaugat')]")]
        public IWebElement confirmationModal { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[contains(@class, 'table-cell')]/span[@class='small']")]
        public IWebElement modalProductName { get; set; }


        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), 'Vezi detalii cos')]")]
        public IWebElement seeBasketModalButton {get; set;}
    }
}
