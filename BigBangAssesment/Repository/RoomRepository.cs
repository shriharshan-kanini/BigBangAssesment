using BigBangAssesment.Model;
using BigBangAssesment.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories
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
            try
            {
                return _context.Rooms.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Room GetRoomById(int RoomId)
        {
            try
            {
                return _context.Rooms.Find(RoomId);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Room PostRoom(Room room)
        {
            try
            {
                var hotel = _context.Hotels.Find(room.Hotel.HotelId);
                room.Hotel = hotel;
                _context.Rooms.Add(room);
                _context.SaveChanges();
                return room;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Room PutRoom(int RoomId, Room room)
        {
            try
            {
                var r = _context.Hotels.Find(room.Hotel.HotelId);
                room.Hotel = r;
                _context.Entry(room).State = EntityState.Modified;
                _context.SaveChanges();
                return room;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        public Room DeleteRoom(int RoomId)
        {
            try
            {
                var room = _context.Rooms.Find(RoomId);
                if (room != null)
                {
                    _context.Rooms.Remove(room);
                    _context.SaveChanges();
                }
                return room;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }
    }
}
