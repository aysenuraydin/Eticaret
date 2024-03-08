using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {

        // public string? Url { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public int CreatedAt { get; set; }

        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Url).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
        }
    }
}
