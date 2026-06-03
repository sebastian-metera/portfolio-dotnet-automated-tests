using System.Net.Http.Json;
using Automation.Tests.Api.Models;

namespace Automation.Tests.Api.Clients;

public class AuthApiClient
{
    private readonly HttpClient _client;

    public AuthApiClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<HttpResponseMessage> CreateToken(AuthRequest request)
    {
        return await _client.PostAsJsonAsync("/auth", request);
    }
}
