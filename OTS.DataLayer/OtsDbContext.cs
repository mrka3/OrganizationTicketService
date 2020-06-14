using Microsoft.EntityFrameworkCore;
using OTS.DataLayer.Entities.Events;
using OTS.DataLayer.Entities.Users;

namespace OTS.DataLayer
{
    public class OtsDbContext : DbContext
    {
        public OtsDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ots;Username=postgres;Password=1");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEventLink>().HasKey(t => new { t.UserId, t.EventId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserEventLink> UserEventLinks { get; set; }
        public DbSet<Event> Events { get; set; }
        
    }
}