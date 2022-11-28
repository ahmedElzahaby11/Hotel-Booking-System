
namespace HotelBooking.DAL;

public class BookingRepo:GenericRepo<Booking>,IBookingRepo
{
	private readonly HB_Context _context;
	public BookingRepo(HB_Context context):base(context)
	{
		_context = context;
	}

	public List<Booking> GetUserBookings(string id)
	{
		List<Booking> bookings = new List<Booking>();
		foreach (Booking booking in _context.Bookings)
		{
			if (booking.UserId == id)
			{
				bookings.Add(booking);
			}
		}
		return bookings;
	} 

}
