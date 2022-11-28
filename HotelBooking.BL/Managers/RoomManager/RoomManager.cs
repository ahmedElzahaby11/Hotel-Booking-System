

using AutoMapper;
using HotelBooking.DAL;

namespace HotelBooking.BL;
public class RoomManager : IRoomManager
{
    private readonly IRoomRepo _roomRepo;
    private readonly IMapper _mapper;
    public RoomManager(IRoomRepo roomRepo, IMapper mapper)
    {
        _roomRepo = roomRepo;
        _mapper = mapper;
    }
    public void AddRoom(RoomWriteDTO room)
    {
        var dbRoom = _mapper.Map<Room>(room);
        _roomRepo.Add(dbRoom);
        _roomRepo.SaveChanges();
    }

    public List<RoomReadDTO> GetAllRooms()
    {
        var dbRoom = _roomRepo.GetAll();
        foreach (var room in dbRoom)
        {
            _roomRepo.GetBookingRoomsId(room);
        }
        var DTOList=_mapper.Map<List<RoomReadDTO>>(dbRoom);
        return DTOList;
    }
    public RoomReadDTO? GetRoomById(int id)
    {
        var dbRoom = _roomRepo.GetById(id);
        if (dbRoom is null)
        {
            return null;
        }
        _roomRepo.GetBookingRoomsId(dbRoom);
        return _mapper.Map<RoomReadDTO>(dbRoom);
    }
}

