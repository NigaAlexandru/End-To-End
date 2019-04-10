using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework.Helpers
{
   public static class Utilities
    {
        public static void navigateTo(string url)
        {
            WebDriver.Driver.Navigate().GoToUrl(url);
        }

        public static void WaitUntilPageIsLoaded()
        {
            try
            {
                new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(30)).Until(
                 d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch(Exception e) { }
        }

        public static void WaitUntilIsClickable(IWebElement element, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver.Driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void ExplicitWait(int seconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(seconds));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("dummy")));
            }
            catch (WebDriverTimeoutException) { }
        }

        public static void SwitchToModal()
        {
            WebDriver.Driver.SwitchTo().ActiveElement();
        }
    }
}
