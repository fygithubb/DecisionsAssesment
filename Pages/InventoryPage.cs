using System.Threading.Tasks;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;


namespace DecisionsAssesment.Pages
{
    public class InventoryPage
    {
        public async Task AddItemsToCart(IPage page, int count)
        {
            var addButtons = page.Locator("button:has-text('Add to cart')");
            for (int i = 0; i < count; i++)
            {
                await addButtons.Nth(i).ClickAsync();
            }
        }

        public async Task AssertCartItemCount(IPage page, int expectedCount)
        {
            var cartBadge = page.Locator(".shopping_cart_badge");
            await Expect(cartBadge).ToHaveTextAsync(expectedCount.ToString());
        }

        public async Task RemoveOneItem(IPage page)
        {
            var removeButtons = page.Locator("button:has-text('Remove')");
            await removeButtons.First.ClickAsync();
        }

        public async Task OpenCart(IPage page)
        {
            await page.ClickAsync(".shopping_cart_link");
        }
    }
}
