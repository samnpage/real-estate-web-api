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
    public DbSet<TransactionEntity> Transactions { get; set; }
    public DbSet<HomeStyleEntity> HomeStyles {get; set;}


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AgentEntity>().ToTable("Agents");
        builder.Entity<BuyerEntity>().ToTable("Buyers");
        builder.Entity<ListingEntity>().ToTable("Listings");
        builder.Entity<AppointmentEntity>().ToTable("Appointments");
        builder.Entity<TransactionEntity>().ToTable("Transactions");
        builder.Entity<HomeStyleEntity>().ToTable("HomeStyles");
    }
}