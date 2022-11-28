

namespace HotelBooking.BL;

public interface IRoomManager
{
    public List<RoomReadDTO> GetAllRooms();
    void AddRoom(RoomWriteDTO room);
    RoomReadDTO GetRoomById(int id);
}
