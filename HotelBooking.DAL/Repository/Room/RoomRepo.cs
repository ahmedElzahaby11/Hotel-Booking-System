using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBooking.DAL;

public class RoomRepo:GenericRepo<Room>,IRoomRepo
{
	private readonly HB_Context _context;
    public RoomRepo(HB_Context context) : base(context)
	{
		_context = context;
	}

	public void GetBookingRoomsId(Room room)
	{
		bool IsBooked = false;
		foreach(var item in _context.Bookings)
		{
			if(item.RoomId == room.RoomId)
			{
				IsBooked = true;
			}
		}
		if (IsBooked)
		{
            room.RoomStatus = "Booked";
            
		}
		else
		{
            room.RoomStatus = "Available";
        }

    }


}
