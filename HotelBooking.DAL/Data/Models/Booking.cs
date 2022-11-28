
namespace HotelBooking.DAL;

public class Booking
{
    public int BookingId { get; set; }
    public string BookingName { get; set; } = ""; 
    public DateTime BookingDate { get; set; }
    public string Branch { get; set; } = "";
    public string Location { get; set; } = "";
    public string UserId { get; set; } = "";
    public User User { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
}
