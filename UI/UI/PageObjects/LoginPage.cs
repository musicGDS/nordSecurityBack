using Microsoft.Playwright;

namespace UI.PageObjects;

public class LoginPage
{
    private IPage _page;
    private ILocator _emailField;

    public LoginPage(IPage page)
    {
        _page = page;
        _emailField = _page.Locator("#app > div > div > main > form > fieldset > div > span");
    }

    public async Task<bool> EmailFieldExistAsync()
    {
        return await _emailField.IsVisibleAsync();
    }
}