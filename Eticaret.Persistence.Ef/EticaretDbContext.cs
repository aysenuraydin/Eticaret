using System.Runtime.CompilerServices;
using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eticaret.Persistence.Ef;
public class EticaretDbContext : DbContext
{
    public EticaretDbContext(DbContextOptions<EticaretDbContext> options) : base(options)
    {
    }

    public DbSet<CartItem> Categories { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<ProductComment> ProductComment { get; set; }
    public DbSet<ProductImage> ProductImage { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Seller> Seller { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
        new List<Category>() {
            new() { Id=1, Color="pink"},
            new() { Id=4, Color="red"},
            new() { Id=3, Color="blue"}
        }
       );
    }
}