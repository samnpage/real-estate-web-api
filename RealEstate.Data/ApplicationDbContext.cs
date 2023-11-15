using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Entities;

namespace RealEstate.Data;

public class ApplicationDbContext : IdentityDbContext<AgentEntity, IdentityRole<int>, int>
{   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}


    public DbSet<BuyerEntity> Buyers { get; set; }

    public DbSet<AppointmentEntity> Appointments{ get; set; }
    
    public DbSet<ListingEntity> Listings { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AgentEntity>().ToTable("Agent");
        builder.Entity<BuyerEntity>().ToTable("Buyer");
        builder.Entity<ListingEntity>().ToTable("Listings");
    }
}