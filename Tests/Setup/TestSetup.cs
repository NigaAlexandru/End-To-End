using TechTalk.SpecFlow;
using TestFramework;

namespace Tests.Setup
{
    [Binding]
   public class TestSetup
    {
        [AfterScenario]
        [AfterFeature]
        [AfterTestRun]
        public static void FinishExecution()
        {
            if (ScenarioContext.Current.TestError != null)
                Settings.TakeShot();

            WebDriver.Driver.Quit();
            WebDriver.Driver.Close();
        }
    }
}
