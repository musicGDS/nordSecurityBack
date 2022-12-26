using Microsoft.Playwright;

namespace UI.PageObjects;

public class PaymentPage
{
    private IPage _page;
    private ILocator _firstYearPrice;

    public PaymentPage(IPage page)
    {
        _page = page;
        _firstYearPrice = _page.GetByTestId("SelectedCartSummaryCard-total-price");
    }

    public async Task<string?> GetFirstYearPrice()
    {
        return await _firstYearPrice.TextContentAsync();
    }
}