using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
  public class ProductContext : DbContext
  {
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
  }
}