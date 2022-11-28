
namespace HotelBooking.DAL;

public interface IRoomRepo:IGenericRepo<Room>
{
    void GetBookingRoomsId(Room room);
}
