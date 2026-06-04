using System.Net;
using System.Net.Http.Json;
using Automation.Tests.Api.Builders;
using Automation.Tests.Api.Clients;
using Automation.Tests.Api.Models;
using Automation.Tests.Core.Fixtures;

namespace Automation.Tests.Api.Tests;

public class BookingTests : ApiTestBase
{
    private BookingApiClient _bookingApi = null!;

    [SetUp]
    public void SetUp()
    {
        _bookingApi = new BookingApiClient(HttpClient);
    }

    [Test]
    public async Task ShouldShowBookingIds()
    {
        //TODO
    }

    [Test]
    //TO-DO: API returns "418 I'm a Teapot" error - investigate if's expected or something is missing on my side
    public async Task ShouldShowBookingDetails()
    {
        var response = await _bookingApi.GetBooking(1); //TODO: prepare a model+builder for various ids, including the incorrect ones
        var responseBody = await response.Content.ReadAsStringAsync();
        // var responseBody = await response.Content.ReadFromJsonAsync<BookingResponse>();

        TestContext.Progress.WriteLine($"Status: {response.StatusCode}");
        TestContext.Progress.WriteLine($"Response body: {responseBody}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(responseBody, Is.Not.Empty);
        // Assert.That(responseBody.Firstname, Is.EqualTo("Sally"));
        // Assert.That(responseBody.Lastname, Is.EqualTo("Brown"));
        // Assert.That(responseBody.Totalprice, Is.EqualTo(111));
        // Assert.That(responseBody.Depositpaid, Is.EqualTo(true));
        // Assert.That(responseBody.Bookingdates.Checkin, Is.EqualTo("2013-02-23"));
        // Assert.That(responseBody.Bookingdates.Checkout, Is.EqualTo("2014-10-23"));
        // Assert.That(responseBody.Additionalneeds, Is.EqualTo("Breakfast").IgnoreCase);
    }

    [Test]
    //TO-DO: API returns "418 I'm a Teapot" error - investigate if's expected or something is missing on my side
    public async Task ShouldCreateBooking()
    {
        var request = new BookingRequestBuilder().Build();

        var response = await _bookingApi.CreateBooking(request);
        var responseBody = await response.Content.ReadAsStringAsync();
        // var responseBody = await response.Content.ReadFromJsonAsync<BookingResponse>();

        TestContext.Progress.WriteLine($"Status: {response.StatusCode}");
        TestContext.Progress.WriteLine($"Response body: {responseBody}");


        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(responseBody, Does.Contain("bookingid").IgnoreCase);
        // Assert.That(responseBody.Firstname, Is.EqualTo("Sally"));
        // Assert.That(responseBody.Bookingdates.Checkin, Is.EqualTo("2026-10-23"));
    }

    [Test]
    public async Task ShouldUpdateBooking()
    {
        //TODO: implement
    }

    [Test]
    public async Task ShouldPartialUpdateBookingIds()
    {
        //TODO: implement
    }

    [Test]
    public async Task ShouldDeleteBookingIds()
    {
        //TODO: implement
    }
}
