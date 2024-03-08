using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        // public string? Name { get; set; }
        // public decimal Price { get; set; }
        // public string? Details { get; set; }
        // public byte StockAmount { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public bool Enabled { get; set; }
        // public int SellerId { get; set; }
        // public int CategoryId { get; set; }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Price).IsRequired();
            builder.Property(u => u.Details).IsRequired();
            builder.Property(u => u.StockAmount).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.Enabled).IsRequired();
            builder.Property(u => u.SellerId).IsRequired();
            builder.Property(u => u.CategoryId).IsRequired();
        }
    }
}