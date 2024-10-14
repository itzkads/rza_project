using System;
using System.Collections.Generic;

namespace rza_project.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string HotelRoomType { get; set; } = null!;

    public string Availability { get; set; } = null!;

    public decimal PricePerNight { get; set; }

    public int RoomCapacity { get; set; }
}
