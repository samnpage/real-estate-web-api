using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Entities;

namespace RealEstate.Data;

public class ApplicationDbContext : IdentityDbContext<AgentsEntity, IdentityRole<int>, int>
{   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}


    public DbSet<BuyersEntity> Buyers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AgentsEntity>().ToTable("Agents");
        builder.Entity<BuyersEntity>().ToTable("Buyers");
    }
}