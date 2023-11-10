using Microsoft.EntityFrameworkCore;

namespace RealEstate.Data;

public class ApplicationDbContext : DbContext
{   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
}