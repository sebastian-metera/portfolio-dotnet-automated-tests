namespace Automation.Tests.Core.Config;

public class TestConfig
{
    public string ApiBaseUrl { get; set; } = "https://restful-booker.herokuapp.com";
    public string UiBaseUrl { get; set; } = "https://sauce-demo.myshopify.com";

    //This is something to check at some point as UI tests when shopping is covered enough
    // public string UiBaseUrl { get; set; } = "https://www.saucedemo.com";
    public string Browser { get; set; } = "Chromium";
    public bool Headless { get; set; } = true;
    public int TimeoutMs { get; set; } = 30000;

    public static TestConfig Load()
    {
        var config = new TestConfig();

        config.ApiBaseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? config.ApiBaseUrl;

        config.UiBaseUrl = Environment.GetEnvironmentVariable("UI_BASE_URL") ?? config.UiBaseUrl;

        config.Browser = Environment.GetEnvironmentVariable("BROWSER") ?? config.Browser;

        config.Headless = bool.TryParse(
            Environment.GetEnvironmentVariable("HEADLESS"),
            out var headless
        )
            ? headless
            : config.Headless;

        config.TimeoutMs = int.TryParse(
            Environment.GetEnvironmentVariable("TIMEOUT_MS"),
            out var timeout
        )
            ? timeout
            : config.TimeoutMs;

        return config;
    }
}
