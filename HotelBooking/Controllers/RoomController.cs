using HotelBooking.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomManager _roomManager;
        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomReadDTO>> GetRooms()
        {
            return _roomManager.GetAllRooms();
        }
        [HttpPost]
        public ActionResult AddRoom(RoomWriteDTO room)
        {
            _roomManager.AddRoom(room);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<RoomReadDTO> GetRoom(int id)
        {
            var room = _roomManager.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            return room;
        }
    }
}
