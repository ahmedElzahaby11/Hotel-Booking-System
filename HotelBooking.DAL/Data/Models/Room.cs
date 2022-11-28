namespace HotelBooking.DAL;
public class Room
{
    public int RoomId { get; set; }
    public string Type { get; set; } = "";
    public string RoomStatus { get; set; } = "";
    public string Branch { get; set; } = "";
    public string Location { get; set; } = "";
    public int Price { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
