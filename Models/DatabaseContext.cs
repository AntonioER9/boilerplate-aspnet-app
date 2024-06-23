using Microsoft.EntityFrameworkCore;

namespace Models
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Brand> Brands { get; set; }
  }
}