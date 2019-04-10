using Shouldly;
using TechTalk.SpecFlow;
using TestFramework;
using TestFramework.Helpers;
using TestFramework.Pages;

namespace Tests.Steps
{
    [Binding]
   public class LoginFlowsSteps
    {
        ProductPage product = new ProductPage();
        BasketPage basket = new BasketPage();
        LoginPage login = new LoginPage();
        string loginUrl = "https://www.emag.ro/user/login";
        public readonly string productPageUrl = "https://www.emag.ro/televizor-led-smart-samsung-100-cm-40nu7122-4k-ultra-hd-ue40nu7122kxxh/pd/DSLT4FBBM/?ref=most_wished_for_generic-home_1_3&provider=rec&recid=rec_41_rec_41_711dfec9680b29cfa59ce38ca48f4686_1554835837";

        [Given(@"The user accessed the login page")]
        public void GivenTheUserAccessedTheLoginPage()
        {
            Utilities.navigateTo(loginUrl);
            Utilities.WaitUntilPageIsLoaded();
        }

        [When(@"the user enters wrong credentials")]
        public void WhenTheUserEntersWrongCredentials()
        {
            login.emailField.SendKeys("test@test");
            login.submitEmailButton.Click();
            Utilities.ExplicitWait(2);
        }

        [Then(@"An error message is displayed")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            login.errorMessage.Text.ShouldContain("Email invalid");
        }

        [When(@"The user clicks on the back button after inputing an email")]
        public void WhenTheUserClicksOnTheBackButtonAfterInputingAnEmail()
        {
            login.emailField.SendKeys("test@test.net");
            login.submitEmailButton.Click();
            Utilities.ExplicitWait(2);
            login.backButton.Click();
            Utilities.ExplicitWait(2);
        }

        [Then(@"The user is redirected back to email input step")]
        public void ThenTheUserIsRedirectedBackToEmailInputStep()
        {
            WebDriver.Driver.Url.ShouldBe(loginUrl);
        }

        [When(@"The unlogged user tries to complete the purchase flow")]
        public void WhenTheUnloggedUserTriesToCompleteThePurchaseFlow()
        {
            Utilities.navigateTo(productPageUrl);
            Utilities.WaitUntilPageIsLoaded();
            Utilities.ScrollToElement(product.buyButton);
            Utilities.WaitUntilIsClickable(product.buyButton, 10);
            product.buyButton.Click();
            Utilities.ExplicitWait(2);
            Utilities.SwitchToModal();
            Utilities.WaitUntilIsClickable(product.seeBasketModalButton, 20);
            product.seeBasketModalButton.Click();
            Utilities.WaitUntilPageIsLoaded();
            login.continuerOrderButton.Click();
            Utilities.ExplicitWait(2);
        }

        [Then(@"The login form is displayed")]
        public void ThenTheLoginFormIsDisplayed()
        {
            WebDriver.Driver.Url.ShouldBe(loginUrl);
        }

    }
}
