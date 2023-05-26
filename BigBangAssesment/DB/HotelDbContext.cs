using BigBangAssesment.Model;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssesment.DB
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }
    }
}
