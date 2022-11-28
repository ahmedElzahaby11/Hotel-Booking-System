

namespace HotelBooking.BL;

public class RoomReadDTO
{
    public int RoomId { get; set; }
    public string Type { get; set; } = "";
    public string RoomStatus { get; set; } = "";
    public string Branch { get; set; } = "";
    public string Location { get; set; } = "";
    public decimal Price { get; set; }
}
