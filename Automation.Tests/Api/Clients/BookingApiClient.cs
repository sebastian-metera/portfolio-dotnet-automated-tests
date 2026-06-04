using System.Net.Http.Headers;
using System.Net.Http.Json;
using Automation.Tests.Api.Models;

namespace Automation.Tests.Api.Clients;

public class BookingApiClient(HttpClient client)
{
    private readonly HttpClient _client = client;

    public async Task<HttpResponseMessage> GetBookingIds()
    {
        return await _client.GetAsync("/booking/");
    }

    public async Task<HttpResponseMessage> GetBooking(int id)
    {
        return await _client.GetAsync($"/booking/{id}");
    }

    public async Task<HttpResponseMessage> CreateBooking(BookingRequest request)
    {
        return await _client.PostAsJsonAsync("/booking", request);
    }

    public async Task<HttpResponseMessage> DeleteBooking(int id, string token)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/booking/{id}");
        request.Headers.Add("Cookie", $"token={token}");

        return await _client.SendAsync(request);
    }

    public async Task<HttpResponseMessage> UpdateBooking(
        int id,
        string token,
        BookingRequest requestBody
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"/booking/{id}")
        {
            Content = JsonContent.Create(requestBody),
        };

        request.Headers.Add("Cookie", $"token={token}");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return await _client.SendAsync(request);
    }

    // TO-DO: Implement PATCH based on: https://restful-booker.herokuapp.com/apidoc/index.html#api-Booking-PartialUpdateBooking
    // public async Task<HttpResponseMessage> PartialUpdateBooking(){}
}
