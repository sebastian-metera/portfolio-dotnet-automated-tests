using Automation.Tests.Core.Config;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Automation.Tests.Core.Fixtures;

public class UiTestBase : PageTest
{
    protected TestConfig Config = null!;

    [SetUp]
    public async Task UiSetup()
    {
        Config = TestConfig.Load();
        //TODO: make it a base URL to have as a main page to open or a base to open specific sub-page
        // await Page.GotoAsync(Config.UiBaseUrl);
        await Page.ScreenshotAsync(new() { Path = "screenshot.png" });
        Page.SetDefaultTimeout(Config.TimeoutMs);
        Playwright.Selectors.SetTestIdAttribute("id"); //in case I'd like to search for locators using Locator.GetByTestId
    }
}
