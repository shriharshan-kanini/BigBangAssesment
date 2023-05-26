using BigBangAssesment.Model;
using BigBangAssesment.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoom _roomRepository;

        public RoomController(IRoom roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public IEnumerable<Room> Get()
        {
            return _roomRepository.GetRoom();
        }

        [HttpGet("{id}")]
        public Room GetById(int RoomId)
        {
            return _roomRepository.GetRoomById(RoomId);
        }

        [HttpPost]
        public Room PostRoom(Room room)
        {
            return _roomRepository.PostRoom(room);
        }

        [HttpPut("{id}")]
        public Room PutRoom(int RoomId, Room room)
        {
            return _roomRepository.PutRoom(RoomId, room);
        }

        [HttpDelete("{id}")]
        public Room DeleteRoom(int RoomId)
        {
            return _roomRepository.DeleteRoom(RoomId);
        }
    }
}
