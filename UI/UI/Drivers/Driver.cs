using System;
using Microsoft.Playwright;

namespace UI.Drivers
{
    public class Driver: IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = Task.Run(InitializePlaywright);
        }

        public IPage Page => _page.Result;
        
        private async Task<IPage> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                { Headless = false, SlowMo = 5000 });
            return await _browser.NewPageAsync();
        }

        public void Dispose()
        {
            _browser?.CloseAsync();
        }
    }
}