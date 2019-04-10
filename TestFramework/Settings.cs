using OpenQA.Selenium;
using System;

namespace TestFramework
{
    public static class Settings
    {
        public static string Browser = "Chrome";
        public static void TakeShot()
        {
            try
            {
                ITakesScreenshot screenshotHandler = WebDriver.Driver as ITakesScreenshot;
                Screenshot screenshot = screenshotHandler.GetScreenshot();
                string dir = @"C:\Users\niga3\source\repos\End-To-End-Testing\TestFramework\Screenshots";
                string path = dir + DateTime.Now.ToString("HHmmss") + ".jpeg";
                screenshot.SaveAsFile(path , ScreenshotImageFormat.Jpeg);


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
