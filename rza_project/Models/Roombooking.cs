using System;
using System.Collections.Generic;

namespace rza_project.Models;

public partial class Roombooking
{
    public int BookingId { get; set; }

    public int CustomerId { get; set; }

    public string? HotelRoomType { get; set; }

    public DateOnly? CheckinDate { get; set; }

    public DateOnly? CheckoutDate { get; set; }

    public int? NoOfGuests { get; set; }

    public decimal? TotalPrice { get; set; }
}
