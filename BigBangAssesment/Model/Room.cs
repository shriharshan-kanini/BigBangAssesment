using System.ComponentModel.DataAnnotations;

namespace BigBangAssesment.Model
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int Occupancy { get; set; }
        public int Price { get; set; }

        public Hotel? Hotel { get; set; }
    }
}
