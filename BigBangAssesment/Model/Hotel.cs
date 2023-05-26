namespace BigBangAssesment.Model
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set;}
        public string HotelLocation { get; set;}
        public string HotelDescription { get; set;}

        public ICollection<Room> Rooms { get; set; }
    }
}
