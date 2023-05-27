using BigBangAssesment.Model;
using BigBangAssesment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotel _hotelRepository;

        public HotelController(IHotel hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public IEnumerable<Hotel> GetHotel()
        {
            return _hotelRepository.GetHotel();
        }

        [HttpGet("{id}")]
        public Hotel GetById(int id)
        {
            return _hotelRepository.GetHotelById(id);
        }

        [HttpPost]
        public Hotel PostHotel(Hotel hotel)
        {
            return _hotelRepository.PostHotel(hotel);
        }

        [HttpPut("{id}")]
        public Hotel PutHotel(int id, Hotel hotel)
        {
            return _hotelRepository.PutHotel(id, hotel);
        }

        [HttpDelete("{id}")]
        public Hotel DeleteHotel(int id)
        {
            return _hotelRepository.DeleteHotel(id);
        }
    }
}
