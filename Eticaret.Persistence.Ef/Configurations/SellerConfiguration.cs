using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        // public string? Adress { get; set; }
        // public long CallNumber { get; set; }

        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Adress).IsRequired();
            builder.Property(u => u.CallNumber).IsRequired();
        }
    }
}