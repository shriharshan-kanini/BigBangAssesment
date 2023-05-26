namespace BigBangAssesment.Model
{
    public class Room
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int Occupancy { get; set; }
        public int Price { get; set; }

        public Hotel Hotel { get; set; }
    }
}
