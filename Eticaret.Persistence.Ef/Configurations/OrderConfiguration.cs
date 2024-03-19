using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        // public string? OrderCode { get; set; }
        // public string? Address { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public int UserId { get; set; }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // builder.HasOne(o => o.UserFk)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(o => o.UserId);
            builder.HasKey(u => u.Id);
            builder.Property(u => u.OrderCode).IsRequired();
            builder.Property(u => u.Address).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.UserId).IsRequired();

        }
    }
}
