using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        // public byte Quantity { get; set; }
        // public decimal UnitPrice { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public int ProductId { get; set; }
        // public int OrderId { get; set; }

        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Quantity).IsRequired();
            builder.Property(u => u.UnitPrice).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.ProductId).IsRequired();
            builder.Property(u => u.OrderId).IsRequired();
        }
    }
}
