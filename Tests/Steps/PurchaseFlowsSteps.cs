using Shouldly;
using TechTalk.SpecFlow;
using TestFramework;
using TestFramework.Helpers;
using TestFramework.Pages;

namespace Tests.Steps
{
    [Binding]
   public class PurchaseFlowsSteps
    {
        public readonly string productPageUrl = "https://www.emag.ro/televizor-led-smart-samsung-100-cm-40nu7122-4k-ultra-hd-ue40nu7122kxxh/pd/DSLT4FBBM/?ref=most_wished_for_generic-home_1_3&provider=rec&recid=rec_41_rec_41_711dfec9680b29cfa59ce38ca48f4686_1554835837";
        ProductPage product = new ProductPage();
        BasketPage basket = new BasketPage();

        [Given(@"The user accessed a product page")]
        public void GivenTheUserAccessedAProductPage()
        {
            Utilities.navigateTo(productPageUrl);
            Utilities.WaitUntilPageIsLoaded();
        }

        [When(@"The user clicks on the buy button available")]
        public void WhenTheUserClicksOnTheBuyButtonAvailable()
        {
            Utilities.ScrollToElement(product.buyButton);
            Utilities.WaitUntilIsClickable(product.buyButton, 10);
            product.buyButton.Click();
            Utilities.WaitUntilPageIsLoaded();
        }

        [Then(@"The product is successfully added to basket")]
        public void ThenTheProductIsSuccessfullyAddedToBasket()
        {

            Utilities.SwitchToModal();
            Utilities.ExplicitWait(2);
            product.confirmationModal.Displayed.ShouldBe(true);
            product.modalProductName.Text.ShouldContain("televizor");
        }

        [Given(@"The user added a product to basket")]
        public void GivenTheUserAddedAProductToBasket()
        {
            Utilities.navigateTo(productPageUrl);
            Utilities.WaitUntilPageIsLoaded();
            Utilities.ScrollToElement(product.buyButton);
            Utilities.WaitUntilIsClickable(product.buyButton, 10);
            product.buyButton.Click();
            Utilities.ExplicitWait(2);
            Utilities.SwitchToModal();

        }


        [Given(@"The user clicks on see basket button")]
        [When(@"The user clicks on see basket button")]
        public void WhenTheUserClicksOnSeeBasketButton()
        {
            Utilities.WaitUntilIsClickable(product.seeBasketModalButton, 20);
            product.seeBasketModalButton.Click();
            Utilities.WaitUntilPageIsLoaded();
        }

        [Then(@"The user is redirected to basket page")]
        public void ThenTheUserIsRedirectedToBasketPage()
        {
            WebDriver.Driver.Url.Contains("module_go-to-cart_button");
        }

        [When(@"The user clicks on the remove button")]
        public void WhenTheUserClicksOnTheRemoveButton()
        {
            basket.DeleteButton.Click();
            Utilities.ExplicitWait(2);
        }

        [Then(@"The product is successfully removed from the basket")]
        public void ThenTheProductIsSuccessfullyRemovedFromTheBasket()
        {
            Utilities.ExplicitWait(2);
            basket.emptyBasketMessage.Displayed.ShouldBe(true);
        }


    }
}
