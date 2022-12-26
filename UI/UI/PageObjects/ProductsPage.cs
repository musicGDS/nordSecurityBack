using Microsoft.Playwright;

namespace UI.PageObjects;

public class ProductsPage
{
    private IPage _page;
    private ILocator _buyNordVpnButton; 

    public ProductsPage(IPage page)
    {
        _page = page;
        _buyNordVpnButton = _page.GetByText("NordVPN");
    }
    
    public async Task ClickOnNordVpnAsync()
    {
        await _buyNordVpnButton.ClickAsync();
    }
    
    
}