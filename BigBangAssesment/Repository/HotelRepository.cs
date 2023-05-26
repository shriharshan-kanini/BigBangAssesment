﻿using BigBangAssesment.DB;
using BigBangAssesment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace BigBangAssesment.Repository
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
            return _context.Hotels.ToList();
        }

        public Hotel GetHotelById(int HotelId)
        {
            return _context.Hotels.Find(HotelId);
        }

        public Hotel PostHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return hotel;
        }

        public Hotel PutHotel(int HotelId, Hotel hotel)
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

        public Hotel DeleteHotel(int HotelId)
        {
            var hotel = _context.Hotels.Find(HotelId);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
            }
            return hotel;
        }
    }
}
