using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BigBangAssesment.Repository;
using BigBangAssesment.Model;
using System.Collections.Generic;

namespace HotelManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customerRepository;

        public CustomersController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerRepository.GetCustomer();
        }

        [HttpGet("{id}")]
        public Customer GetById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        [HttpPost]
        public Customer PostCustomer(Customer customer)
        {
            return _customerRepository.PostCustomer(customer);
        }

        [HttpPut("{id}")]
        public Customer PutCustomer(int id, Customer customer)
        {
            return _customerRepository.PutCustomer(id, customer);
        }

        [HttpDelete("{id}")]
        public Customer DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }
        [HttpGet("Filter")]
        public IEnumerable<Hotel> FilterHotel(string HotelLocation)
        {
            return _customerRepository.FilterHotel(HotelLocation);
        }
        [HttpGet("Occupancy")]
        public int GetRoomOccupancy(int RoomId, int HotelId)
        {
            return _customerRepository.GetRoomOccupancy(RoomId, HotelId);
        }
    }
}
