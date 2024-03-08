using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        // public string? Name { get; set; }
        // public string? Color { get; set; }
        // public string? IconCssClass { get; set; }
        // public DateTime CreatedAt { get; set; }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Color).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
        }
    }
}