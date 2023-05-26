using BigBangAssesment.DB;
using BigBangAssesment.Model;
using System.Collections.Generic;
using System.Linq;

namespace BigBangAssesment.Repository
{
    public class RoomRepository : IRoom
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetRoom()
        {
            return _context.Rooms.ToList();
        }

        public Room GetRoomById(int RoomId)
        {
            return _context.Rooms.Find(RoomId);
        }

        public Room PostRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return room;
        }

        public Room PutRoom(int RoomId, Room room)
        {
            var existingRoom = _context.Rooms.Find(RoomId);
            if (existingRoom != null)
            {
                existingRoom.Occupancy = room.Occupancy;
                existingRoom.Price = room.Price;

                _context.SaveChanges();
            }
            return existingRoom;
        }

        public Room DeleteRoom(int RoomId)
        {
            var room = _context.Rooms.Find(RoomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
            return room;
        }
    }
}
