using HotelBooking.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager= bookingManager;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<BookingReadDTO> GetBooking(int id)
        {
            var booking=_bookingManager.GetBookingById(id);
            if(booking == null)
            {
                return NotFound();
            }
            return booking;
        }

        [HttpPost]
        public ActionResult PostBooking(BookingWriteDTO booking)
        {
            var BookingRead=_bookingManager.AddBooking(booking);
            return CreatedAtAction("GetBooking", new {id=BookingRead.BookingId},BookingRead);
        }
        [HttpGet("{UserId}")]
        public ActionResult<IEnumerable<BookingReadDTO>> GetUserBookings(string UserId)
        {
            var UserBookings = _bookingManager.GetUserBooking(UserId);
            if(UserBookings == null)
                return NotFound();
            return Ok(UserBookings);
        }
        [HttpDelete("{id}")]
        public ActionResult CanselBooking(int id)
        {
            _bookingManager.CancelBooking(id);
            return NoContent();
        }
        
    }
}
