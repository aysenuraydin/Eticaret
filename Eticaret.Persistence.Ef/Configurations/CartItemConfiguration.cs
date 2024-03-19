using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {

        // public byte Quantity { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public int ProductId { get; set; }

        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Quantity).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.ProductId).IsRequired();
        }
    }
}