
namespace HotelBooking.BL;

public class BookingReadDTO
{
    public int BookingId { get; set; }
    public string BookingName { get; set; } = "";
    public int RoomId { get; set; }
    public DateTime BookingDate { get; set; }
    public string Branch { get; set; } = "";
    public string Location { get; set; } = "";
}
