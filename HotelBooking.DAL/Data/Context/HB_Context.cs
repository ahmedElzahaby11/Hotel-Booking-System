
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL;

public class HB_Context:IdentityDbContext<User>
{
    public HB_Context()
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    public HB_Context(DbContextOptions<HB_Context> options) :base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToTable("User");
    }
}
