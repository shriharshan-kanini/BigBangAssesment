using BigBangAssesment.Model;
using BigBangAssesment.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelManagement.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly HotelDbContext _context;

        public CustomerRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomer()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int CustomerId)
        {
            return _context.Customers.Find(CustomerId);
        }

        public Customer PostCustomer(Customer customer)
        {
            var hotel = _context.Hotels.Find(customer.Hotel.HotelId);
            customer.Hotel = hotel;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer PutCustomer(int CustomerId, Customer customer)
        {
            var hotel = _context.Hotels.Find(customer.Hotel.HotelId);
            customer.Hotel = hotel;
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(int CustomerId)
        {
            var customer = _context.Customers.Find(CustomerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            return customer;
        }

        public IEnumerable<Hotel> FilterHotel(string HotelLocation)
        {
            var filteredHotels = _context.Hotels.AsQueryable();

            if (!string.IsNullOrEmpty(HotelLocation))
            {
                filteredHotels = filteredHotels.Where(h => h.HotelLocation.Contains(HotelLocation));
            }

            return filteredHotels.ToList();
        }

        public int GetRoomOccupancy(int RoomId, int HotelId)
        {
            var count = (from Room in _context.Rooms
                         join hotel in _context.Hotels on Room.Hotel.HotelId equals hotel.HotelId
                         where Room.RoomId == RoomId && hotel.HotelId == HotelId
                         select Room.Occupancy).FirstOrDefault();

            return count;
        }
    }
}
