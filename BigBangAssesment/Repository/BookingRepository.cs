using BigBangAssesment.Model;
using BigBangAssesment.Repository;

namespace HotelManagement.Repositories
{
    public class BookingRepository : IBooking
    {
        private readonly HotelDbContext _context;

        public BookingRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetBooking()
        {
            try
            {
                return _context.Bookings.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        public Booking GetBookingById(int BookingId)
        {
            try
            {
                return _context.Bookings.Find(BookingId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        public Booking PostBooking(Booking booking)
        {
            try
            {
                var b = _context.Hotels.Find(booking.Hotel.HotelId);
                booking.Hotel = b;
                var room = _context.Rooms.Find(booking.Room.RoomId);
                booking.Room = room;

                var customer = _context.Customers.Find(booking.Customer.CustomerId);
                booking.Customer = customer;

                _context.Add(booking);
                _context.SaveChanges();
                return booking;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        public Booking PutBooking(int BookingId, Booking booking)
        {
            try
            {
                var existingBooking = _context.Bookings.Find(BookingId);
                if (existingBooking != null)
                {
                    existingBooking.CheckInDate = booking.CheckInDate;
                    existingBooking.CheckOut = booking.CheckOut;
                    existingBooking.Room = booking.Room;

                    _context.SaveChanges();
                }
                return existingBooking;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }

        public Booking DeleteBooking(int BookingId)
        {
            try
            {
                var booking = _context.Bookings.Find(BookingId);
                if (booking != null)
                {
                    _context.Bookings.Remove(booking);
                    _context.SaveChanges();
                }
                return booking;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null; 
            }
        }
    }
}
