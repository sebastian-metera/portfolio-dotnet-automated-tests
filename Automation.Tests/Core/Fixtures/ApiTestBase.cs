using Automation.Tests.Core.Config;

namespace Automation.Tests.Core.Fixtures;

public class ApiTestBase
{
    protected TestConfig Config = null!;
    protected HttpClient HttpClient = null!;

    [SetUp]
    public void ApiSetUp()
    {
        Config = TestConfig.Load();

        HttpClient = new HttpClient
        {
            BaseAddress = new Uri(Config.ApiBaseUrl),
            Timeout = TimeSpan.FromMilliseconds(Config.TimeoutMs),
        };
    }

    [TearDown]
    public void ApiTearDown()
    {
        HttpClient.Dispose();
    }
}
