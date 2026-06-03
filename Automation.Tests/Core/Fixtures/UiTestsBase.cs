using Automation.Tests.Core.Config;
using Microsoft.Playwright.NUnit;

namespace Automation.Tests.Core.Fixtures;

public class UiTestBase : PageTest
{
    protected TestConfig Config = null!;

    [SetUp]
    public void UiSetup()
    {
        Config = TestConfig.Load();
        Page.SetDefaultTimeout(Config.TimeoutMs);
    }
}
