using Microsoft.Playwright;

namespace UI.PageObjects;

public class NordVpnPlanPage
{
    private IPage _page;
    private ILocator _loginButton;
    private ILocator _oneYearPlan;
    private ILocator _oneYearPlanPrice;
    private ILocator _continueToPaymentButton;

    public NordVpnPlanPage(IPage page)
    {
        _page = page;
        _oneYearPlan =
            _page.Locator(
                "#__next > div > main > div > div:nth-child(1) > div.mb-7.md\\:mb-10 > div > div:nth-child(2) > div > button > div");
        _oneYearPlanPrice = _page.Locator(
            "#__next > div > main > div > div:nth-child(1) > div.mb-7.md\\:mb-10 > div > div:nth-child(2) > div > button > div > div > div.flex-grow.self-stretch.font-medium > div > div.nord-text.text-micro.leading-normal.font-medium.text-grey-dark > span");
        _continueToPaymentButton = _page.Locator("#__next > div > main > div > div.fixed.bottom-0.w-full.z-9999 > div > div > div > div:nth-child(1) > a");
        _loginButton = _page.GetByTestId("UserProfile-login-button");
    }

    public async Task SelectOneYearPlanAsync()
    {
        await _oneYearPlan.ClickAsync();
    }

    public async Task PressContinuePaymentButtonAsync()
    {
        await _continueToPaymentButton.ClickAsync();
    }

    public async Task PressLoginButtonAsync()
    {
        await _loginButton.ClickAsync();
    }

    public async Task<string?> GetFirstYearPriceAsync()
    {
        return await _oneYearPlanPrice.TextContentAsync();
    }
}