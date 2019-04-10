using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace TestFramework
{
    public class WebDriver
    {
        public static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    switch (Settings.Browser)
                    {
                        case "Chrome":
                            InitializeChrome();
                            break;

                        case "Firefox":
                            InitializeFirefox();
                            break;
                    }
                }
                return _driver;
            }
        }
        public static void InitializeChrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            //options.AddArgument("--headless");
            options.AddArgument("incognito");

            _driver = new ChromeDriver(@"C:\Users\niga3\source\repos\End-To-End-Testing\TestFramework\Drivers\", options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public static void InitializeFirefox()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\abcd\Downloads\geckodriver-v0.13.0-win64", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";

            _driver = new FirefoxDriver(service);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public static void Quit()
        {
            if (_driver == null)
                return;

            _driver.Quit();
            _driver.Dispose();
            _driver = null;
        }
    }
}
