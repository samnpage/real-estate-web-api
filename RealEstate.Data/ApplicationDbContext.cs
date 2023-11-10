using Microsoft.EntityFrameworkCore;
using RealEstate.Data.Entities;

namespace RealEstate.Data;

public class ApplicationDbContext : DbContext
{   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<BuyersEntity> Buyers { get; set; }
}