﻿using System.ComponentModel.DataAnnotations;

namespace BigBangAssesment.Model
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOut { get; set; }
        public Hotel? Hotel { get; set; }
        public Room? Room { get; set; }
        public Customer? Customer { get; set; }
        public Booking()
        {
            BookedDate = DateTime.Now;
        }
    }
}
