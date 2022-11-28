
using Microsoft.AspNetCore.Identity;

namespace HotelBooking.DAL;
public class User:IdentityUser
{
    public string address { get; set; } = "";
    public ICollection<Booking> Bookings { get; set; }= new HashSet<Booking>();
}
