using InvestmentProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvestmentProj.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        // Define DbSets for your other entities
        public DbSet<Booking> Bookings { get; set; }
        // Add more DbSets here if needed, for example:
        // public DbSet<Room> Rooms { get; set; }

        // Optional: Override OnModelCreating if you need custom configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add custom model configurations here if needed
            // For example, you can configure relationships or entity properties

            // Example configuration
            // modelBuilder.Entity<Booking>()
            //     .HasOne(b => b.Room)
            //     .WithMany(r => r.Bookings)
            //     .HasForeignKey(b => b.RoomId);
        }
    }
}
