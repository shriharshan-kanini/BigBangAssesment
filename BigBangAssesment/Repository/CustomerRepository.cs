using BigBangAssesment.DB;
using BigBangAssesment.Model;
using System.Collections.Generic;
using System.Linq;

namespace BigBangAssesment.Repository
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
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer PutCustomer(int CustomerId, Customer customer)
        {
            var existingCustomer = _context.Customers.Find(CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerName = customer.CustomerName;
                existingCustomer.CustomerNumber = customer.CustomerNumber;

                _context.SaveChanges();
            }
            return existingCustomer;
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
    }
}
