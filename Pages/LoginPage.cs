using System.Threading.Tasks;
using Microsoft.Playwright;

namespace DecisionsAssesment.Pages
{
    public class LoginPage
    {
        public async Task Login(IPage page, string username, string password)
        {
            await page.FillAsync("#user-name", username);
            await page.FillAsync("#password", password);
            await page.ClickAsync("#login-button");
        }
    }
}
