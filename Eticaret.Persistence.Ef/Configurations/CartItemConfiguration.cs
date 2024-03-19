using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Quantity).IsRequired();
            builder.Property(u => u.UserId).IsRequired();
            builder.Property(u => u.ProductId).IsRequired();

            // builder.HasOne(u => u.ProductFk)
            //            .WithMany()
            //            .HasForeignKey(u => u.ProductId)
            //            .OnDelete(DeleteBehavior.Cascade);
            // builder.HasOne(u => u.UserFk)
            //            .WithMany()
            //            .HasForeignKey(u => u.ProductId)
            //            .OnDelete(DeleteBehavior.Cascade);


        }
    }
}