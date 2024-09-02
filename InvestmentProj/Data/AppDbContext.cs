using InvestmentProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InvestmentProj.Models;
using IvestmentProj.Models;

namespace InvestmentProj.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize the ASP.NET Identity model if needed
            // For example, you could rename the AspNetUsers table to ApplicationUser
            // modelBuilder.Entity<AppUser>().ToTable("ApplicationUser");

            // Configure your custom models here
            // modelBuilder.Entity<Room>().ToTable("Rooms");
            // modelBuilder.Entity<Booking>().ToTable("Bookings");
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
