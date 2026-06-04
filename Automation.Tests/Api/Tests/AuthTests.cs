namespace Automation.Tests.Api.Tests;

using System.Net;
using System.Net.Http.Json;
using Automation.Tests.Api.Builders;
using Automation.Tests.Api.Clients;
using Automation.Tests.Api.Models;
using Automation.Tests.Core.Fixtures;

public class AuthTests : ApiTestBase
{
    private AuthApiClient _AuthApi = null!;

    [SetUp]
    public void SetUp()
    {
        _AuthApi = new AuthApiClient(HttpClient);
    }

    [Test]
    public async Task ShouldReceiveAuthToken()
    {
        var request = new AuthRequestBuilder().Build();

        var response = await _AuthApi.CreateToken(request);
        var responseBody = await response.Content.ReadAsStringAsync();
        var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();

        // TestContext.Progress.WriteLine($"Status: {response.StatusCode}");
        // TestContext.Progress.WriteLine($"Response body: {responseBody}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(responseBody, Is.Not.Null);
        Assert.That(authResponse, Is.Not.Null);
        Assert.That(authResponse.Token, Is.TypeOf<string>());
        Assert.That(authResponse.Token, Is.Not.Empty);
    }

    [Test]
    public async Task ShouldNotReceiveAuthTokenWithInvalidUsername()
    {
        var request = new AuthRequestBuilder().WithInvalidUsername().Build();

        var response = await _AuthApi.CreateToken(request);
        var responseBody = await response.Content.ReadAsStringAsync();

        Assert.That(response.StatusCode, Is.InRange(200, 299)); //maybe it returns 2xx with error/failure details
        Assert.That(responseBody, Does.Not.Contain("success").IgnoreCase);
    }

    [Test]
    public async Task ShouldNotReceiveAuthTokenWithInvalidPassword()
    {
        var request = new AuthRequestBuilder().WithInvalidPassword().Build();

        var response = await _AuthApi.CreateToken(request);
        var responseBody = await response.Content.ReadAsStringAsync();
        // var responseBody = await response.Content.ReadFromJsonAsync<AuthResponse>();

        TestContext.Progress.WriteLine($"Status: {response.StatusCode}");
        TestContext.Progress.WriteLine($"Response body: {responseBody}");

        // Assert.That(response.StatusCode, Is.Not.InRange(200, 299)); //wrong assumption, it doesn't send error code
        Assert.That(response.StatusCode, Is.InRange(200, 299)); //it returns 2xx with "reason" in body
        Assert.That(responseBody, Does.Not.Contain("token").IgnoreCase);
        Assert.That(responseBody, Does.Contain("Bad credentials").IgnoreCase);
    }
}
