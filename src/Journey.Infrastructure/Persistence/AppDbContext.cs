
using Journey.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Activity> Activities { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source=C:\\Users\\dnlus\\Downloads\\Journey\\Journey\\src\\JourneyDatabase.db");
        }
    }
}
