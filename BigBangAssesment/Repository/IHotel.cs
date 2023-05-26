using BigBangAssesment.Model;

namespace BigBangAssesment.Repository
{
    public interface IHotel
    {
        public IEnumerable<Hotel> GetHotel();
        public Hotel GetHotelById(int HotelId);
        public Hotel PostHotel(Hotel hotel);
        public Hotel PutHotel(int HotelId, Hotel hotel);
        public Hotel DeleteHotel(int HotelId);
    }
}
