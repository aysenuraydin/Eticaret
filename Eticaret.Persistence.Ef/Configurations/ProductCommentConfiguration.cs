using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class ProductCommentConfiguration : IEntityTypeConfiguration<ProductComment>
    {

        // public string? Text { get; set; }
        // public byte StarCount { get; set; }
        // public bool IsConfirmed { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public int UserId { get; set; }
        // public int ProductId { get; set; }

        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.StarCount).IsRequired();
            builder.Property(u => u.IsConfirmed).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
            builder.Property(u => u.UserId).IsRequired();
            builder.Property(u => u.ProductId).IsRequired();
        }
    }
}