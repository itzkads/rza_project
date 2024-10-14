using System;
using System.Collections.Generic;

namespace rza_project.Models;

public partial class Ticketbooking
{
    public int BookingId { get; set; }

    public int TicketId { get; set; }

    public DateOnly VisitDate { get; set; }

    public decimal TicketPrice { get; set; }

    public DateOnly BookingDate { get; set; }

    public int NoOfGuests { get; set; }

    public int LoyaltyPoints { get; set; }
}
