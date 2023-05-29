using BigBangAssesment.Model;
using BigBangAssesment.Repository;
using Microsoft.EntityFrameworkCore;

namespace AssessmentAPI.Repositories
{
    public class HotelRepository : IHotel
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hotel> GetHotel()
        {
            try
            {
                return _context.Hotels.Include(x => x.Rooms).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Hotel GetHotelById(int HotelId)
        {
            try
            {
                return _context.Hotels.Find(HotelId);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Hotel PostHotel(Hotel hotel)
        {
            try
            {
                _context.Hotels.Add(hotel);
                _context.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Hotel PutHotel(int HotelId, Hotel hotel)
        {
            try
            {
                var existingHotel = _context.Hotels.Find(HotelId);
                if (existingHotel != null)
                {
                    existingHotel.HotelName = hotel.HotelName;
                    existingHotel.HotelDescription = hotel.HotelDescription;
                    existingHotel.HotelLocation = hotel.HotelLocation;
                    _context.SaveChanges();
                }
                return existingHotel;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Hotel DeleteHotel(int HotelId)
        {
            try
            {
                var hotel = _context.Hotels.Find(HotelId);
                if (hotel != null)
                {
                    _context.Hotels.Remove(hotel);
                    _context.SaveChanges();
                }
                return hotel;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }
    }
}
