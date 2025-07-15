using DecisionsAssesment.Pages;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DecisionsAssesment.Tests
{
    [TestFixture]
    public class SauceDemoTest
    {
        [Test]
        public async Task CompleteSauceDemoPurchaseTest()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://www.saucedemo.com/");

            // Call to Login page and details upload
            var loginPage = new LoginPage();
            await loginPage.Login(page, "standard_user", "secret_sauce");

            // Inventory page product added to card any products.
            var inventoryPage = new InventoryPage();
            await inventoryPage.AddItemsToCart(page, 2);
            await inventoryPage.AssertCartItemCount(page, 2);
            await inventoryPage.RemoveOneItem(page);
            await inventoryPage.AssertCartItemCount(page, 1);
            await inventoryPage.OpenCart(page);

            // checking out cart products are selected.
            var cartPage = new CartPage();
            await cartPage.AssertRemainingItem(page);
            await cartPage.Checkout(page);

            // putting details and checking out.
            var checkoutPage = new CheckoutPage();
            await checkoutPage.FillCustomerInformation(page, "Anas", "Khan", "400001");
            await checkoutPage.AssertItemInOverview(page);
            await checkoutPage.FinishOrder(page);
            await checkoutPage.AssertConfirmationMessage(page);

            await browser.CloseAsync();
        }
    }
}
