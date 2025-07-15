using System.Threading.Tasks;
using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;


namespace DecisionsAssesment.Pages
{
    public class CheckoutPage
    {
        public async Task FillCustomerInformation(IPage page, string firstName, string lastName, string postalCode)
        {
            await page.FillAsync("#first-name", firstName);
            await page.FillAsync("#last-name", lastName);
            await page.FillAsync("#postal-code", postalCode);
            await page.ClickAsync("#continue");
        }

        public async Task AssertItemInOverview(IPage page)
        {
            var item = page.Locator(".cart_item");
            await Expect(item).ToBeVisibleAsync();
        }

        public async Task FinishOrder(IPage page)
        {
            await page.ClickAsync("#finish");
        }

        public async Task AssertConfirmationMessage(IPage page)
        {
            var confirmation = page.Locator(".complete-header");
            await Expect(confirmation).ToHaveTextAsync("Thank you for your order!");
        }
    }
}
