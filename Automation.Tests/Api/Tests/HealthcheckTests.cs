using System.Net;
using Automation.Tests.Api.Clients;
using Automation.Tests.Core.Fixtures;

namespace Automation.Tests.Api.Tests;

public class HealthcheckTests : ApiTestBase
{
    private HealthcheckApiClient _bookingApi = null!;

    [SetUp]
    public void SetUp()
    {
        _bookingApi = new HealthcheckApiClient(HttpClient);
    }

    [Test]
    public async Task ShouldBeRunning()
    {
        var response = await _bookingApi.GetPing();
        TestContext.Progress.WriteLine($"Status: {response.StatusCode}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }
}
