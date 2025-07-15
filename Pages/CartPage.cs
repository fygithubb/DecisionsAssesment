using System.Threading.Tasks;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;


namespace DecisionsAssesment.Pages
{
    public class CartPage
    {
        public async Task AssertRemainingItem(IPage page)
        {
            var cartItems = page.Locator(".cart_item");
            await Expect(cartItems).ToHaveCountAsync(1);
        }

        public async Task Checkout(IPage page)
        {
            await page.ClickAsync("#checkout");
        }
    }
}
