namespace Automation.Tests.Api.Clients;

public class HealthcheckApiClient(HttpClient client)
{
    private readonly HttpClient _client = client;

    public async Task<HttpResponseMessage> GetPing()
    {
        return await _client.GetAsync("/ping");
    }
}
