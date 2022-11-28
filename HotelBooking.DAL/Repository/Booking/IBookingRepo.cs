

namespace HotelBooking.DAL;
public interface IBookingRepo:IGenericRepo<Booking>
{
    List<Booking> GetUserBookings(string id);
}
