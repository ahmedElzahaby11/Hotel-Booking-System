
using HotelBooking.DAL;

namespace HotelBooking.BL;
public class BookingWriteDTO
{
    public int BookingId { get; set; }
    public string BookingName { get; set; } = "";
    public int RoomId { get; set; }
    public DateTime BookingDate { get; set; }
    public string Branch { get; set; } = "";
    public string Location { get; set; } = "";
    public string UserId { get; set; } = "";

}
