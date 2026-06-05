namespace Automation.Tests.Api.Models;

public class CreateBookingResponse
{
    public int Bookingid { get; set; }
    public BookingResponse Booking { get; set; } = new();
}
