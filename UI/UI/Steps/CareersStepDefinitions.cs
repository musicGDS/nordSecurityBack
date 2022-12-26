using FluentAssertions;
using Microsoft.Playwright;
using UI.Drivers;
using UI.PageObjects;

namespace UI.Steps;

[Binding]
public sealed class CareersStepDefinitions
{
    private Driver _driver;
    private ProductsPage _productsPage;
    private LoginPage _loginPage;
    private NordVpnPlanPage _nordVpnPage;
    private PaymentPage _paymentPage;

    private string? _firstYearPrice;
    
    public CareersStepDefinitions(Driver driver)
    {
        _driver = driver;
        _productsPage = new (_driver.Page);
        _loginPage = new (_driver.Page);
        _nordVpnPage = new (_driver.Page);
        _paymentPage = new(_driver.Page);
    }

    [When(@"user navigates to the products page")]
    public async Task WhenUserNavigatesToTheProductsPageAsync()
    {
        await  _driver.Page.GotoAsync("https://nordcheckout.com/products/");
    }

    [When(@"user clicks on buy NordVPN")]
    public async Task WhenUserClicksOnBuyNordVpnAsync()
    {
        await _productsPage.ClickOnNordVpnAsync();
    }
    
    [When(@"user clicks login button")]
    public async Task WhenUserClicksLoginButtonAsync()
    {
        await _nordVpnPage.PressLoginButtonAsync();
    }

    [Then(@"email field is present")]
    public async Task ThenEmailFieldIsPresentAsync()
    {
        var existAsync = await _loginPage.EmailFieldExistAsync();
        existAsync.Should().BeTrue();
    }
    
    [When(@"user goes back")]
    public async Task WhenUserGoesBackAsync()
    {
        await _driver.Page.GoBackAsync();
    }

    [When(@"user selects one year plan")]
    public async Task WhenUserSelectsOneYearPlanAsync()
    {
        await _nordVpnPage.SelectOneYearPlanAsync();
    }

    [When(@"store one year plan price")]
    public async Task WhenStoreOneYearPlanPriceAsync()
    {
        _firstYearPrice = await _nordVpnPage.GetFirstYearPriceAsync();
    }

    [When(@"user clicks continue on payment")]
    public async Task WhenUserClicksContinueOnPaymentAsync()
    {
        await _nordVpnPage.PressContinuePaymentButtonAsync();
    }

    [Then(@"the yearly price should match")]
    public async Task ThenTheYearlyPriceShouldMatchAsync()
    {
        var actualPrice = await _paymentPage.GetFirstYearPrice();
        actualPrice.Should().Be(_firstYearPrice);
    }
}