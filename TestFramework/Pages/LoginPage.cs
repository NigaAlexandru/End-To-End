using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Pages
{
    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(WebDriver.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement emailField{ get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[contains(@class, 'gui-btn')]")]
        public IWebElement submitEmailButton{ get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[contains(@class, 'gui-input-explain -is-error')]")]
        public IWebElement errorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), 'inapoi')]")]
        public IWebElement backButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//a[contains(@class, 'emg-btn-large')]")]
        public IWebElement continuerOrderButton { get; set; }
    }
}
