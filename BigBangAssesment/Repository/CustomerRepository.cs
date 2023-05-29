using BigBangAssesment.Model;
using BigBangAssesment.Repository;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Customer GetCustomerById(int CustomerId)
        {
            try
            {
                return _context.Customers.Find(CustomerId);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Customer PostCustomer(Customer customer)
        {
            try
            {
                var hotel = _context.Hotels.Find(customer.Hotel.HotelId);
                customer.Hotel = hotel;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Customer PutCustomer(int CustomerId, Customer customer)
        {
            try
            {
                var hotel = _context.Hotels.Find(customer.Hotel.HotelId);
                customer.Hotel = hotel;
                _context.Entry(customer).State = EntityState.Modified;
                _context.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Customer DeleteCustomer(int CustomerId)
        {
            try
            {
                var customer = _context.Customers.Find(CustomerId);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public IEnumerable<Hotel> FilterHotel(string HotelLocation)
        {
            try
            {
                var filteredHotels = _context.Hotels.AsQueryable();

                if (!string.IsNullOrEmpty(HotelLocation))
                {
                    filteredHotels = filteredHotels.Where(h => h.HotelLocation.Contains(HotelLocation));
                }
                return filteredHotels.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public int GetRoomOccupancy(int RoomId, int HotelId)
        {
            try
            {
                var count = (from Room in _context.Rooms
                             join hotel in _context.Hotels on Room.Hotel.HotelId equals hotel.HotelId
                             where Room.RoomId == RoomId && hotel.HotelId == HotelId
                             select Room.Occupancy).FirstOrDefault();

                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }
    }
}
