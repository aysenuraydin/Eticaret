using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        // public string? Name { get; set; }
        // public DateTime CreatedAt { get; set; }

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
        }
    }



}