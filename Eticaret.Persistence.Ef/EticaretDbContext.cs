

using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;

using System.Reflection;
using Eticaret.Persistence.Ef.SeedDatas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Eticaret.Persistence.Ef;
public class EticaretDbContext : IdentityDbContext<User, Role, int>
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