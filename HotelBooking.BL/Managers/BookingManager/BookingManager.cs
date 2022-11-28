
using AutoMapper;
using HotelBooking.DAL;

namespace HotelBooking.BL;
public class BookingManager : IBookingManager
{
    private readonly IBookingRepo _bookingRepo;
    private readonly IMapper _mapper;
    public BookingManager(IBookingRepo bookingRepo, IMapper mapper)
    {
        _bookingRepo = bookingRepo;
        _mapper = mapper;
    }
    public BookingReadDTO AddBooking(BookingWriteDTO booking)
    {
        var dbBooking = _mapper.Map<Booking>(booking);
        _bookingRepo.Add(dbBooking);
        _bookingRepo.SaveChanges();
        return _mapper.Map<BookingReadDTO>(dbBooking);
    }

    public BookingReadDTO GetBookingById(int id)
    {
        var dbBooking = _bookingRepo.GetById(id);
        if (dbBooking is null)
            return null;
        return _mapper.Map<BookingReadDTO>(dbBooking);
    }

    public List<BookingReadDTO> GetUserBooking(string id)
    {
        var dbBooking=_bookingRepo.GetUserBookings(id);
        if (dbBooking is null)
            return null;
        return _mapper.Map<List<BookingReadDTO>>(dbBooking);
    }

    public void CancelBooking (int id)
    {
        var dbBooking=_bookingRepo.GetById(id);
        if (dbBooking is null)
            return;
        _bookingRepo.Delete(dbBooking);
        _bookingRepo.SaveChanges();
    }
}
