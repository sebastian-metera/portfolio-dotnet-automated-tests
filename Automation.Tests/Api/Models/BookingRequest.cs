namespace Automation.Tests.Api.Models;

public class BookingRequest
{
    public string Firstname { get; set; } = "";
    public string Lastname { get; set; } = "";
    public decimal Totalprice { get; set; }
    public bool Depositpaid { get; set; }
    public BookingDates Bookingdates { get; set; } = new();
    public string Additionalneeds { get; set; } = "";
}
