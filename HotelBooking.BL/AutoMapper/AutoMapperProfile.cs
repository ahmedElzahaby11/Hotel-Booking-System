
using AutoMapper;
using HotelBooking.DAL;

namespace HotelBooking.BL;
public class AutoMapperProfile:Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Room,RoomReadDTO>();
		CreateMap<BookingWriteDTO,Booking>();
		CreateMap<Booking,BookingReadDTO>();
		CreateMap<RoomWriteDTO, Room>();
	}

}
