using System.ComponentModel.DataAnnotations;

namespace BigBangAssesment.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? CustomerNumber { get; set;}
        public ICollection<Booking>? Bookings { get; set; }
        public Hotel? Hotel { get; set; } 
    }
}
