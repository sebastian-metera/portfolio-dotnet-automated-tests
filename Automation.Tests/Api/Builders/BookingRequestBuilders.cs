using Automation.Tests.Api.Models;

namespace Automation.Tests.Api.Builders;

public class BookingRequestBuilder
{
    private string _firstname = "Sally";
    private string _lastname = "Brown";
    private decimal _totalprice = 123m;
    private bool _depositpaid = true;
    private string _checkin = "2026-10-23";
    private string _checkout = "2026-10-26";
    private string _additionalneeds = "Breakfast";

    public BookingRequestBuilder WithInvalidDates()
    {
        _checkin = "2022-02-20";
        _checkout = "2020-02-22";
        return this;
    }

    public BookingRequest Build()
    {
        return new BookingRequest
        {
            Firstname = _firstname,
            Lastname = _lastname,
            Totalprice = _totalprice,
            Depositpaid = _depositpaid,
            Bookingdates = new BookingDates { Checkin = _checkin, Checkout = _checkout },
            Additionalneeds = _additionalneeds,
        };
    }
}
