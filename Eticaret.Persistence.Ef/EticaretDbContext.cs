

using System.Runtime.CompilerServices;
using Eticaret.Domain;
using Eticaret.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;
using Eticaret.Persistence.Ef.SeedDatas;


namespace Eticaret.Persistence.Ef;
public class EticaretDbContext : DbContext
{
    public EticaretDbContext(DbContextOptions<EticaretDbContext> options) : base(options)
    {
        // Eğer veritabanı oluşturulurken test verilerini eklemek istiyorsanız:
        // Database.EnsureCreated();
    }

    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<ProductComment> ProductComments { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(
        Assembly.GetExecutingAssembly(),
        t => t.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) &&
                typeof(EticaretDbContext).IsAssignableFrom(i.GenericTypeArguments[0]))
        );

        modelBuilder.SeedData();
        base.OnModelCreating(modelBuilder);
    }
}