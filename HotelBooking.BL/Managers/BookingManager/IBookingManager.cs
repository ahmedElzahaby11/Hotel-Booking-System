
namespace HotelBooking.BL;

public interface IBookingManager
{
    BookingReadDTO AddBooking(BookingWriteDTO booking);
    BookingReadDTO GetBookingById(int id);
    List<BookingReadDTO> GetUserBooking(string id);
    void CancelBooking (int id);

}
