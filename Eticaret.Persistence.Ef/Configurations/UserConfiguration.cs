using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Persistence.Ef.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        //Id int PK, Identity, required
        //Email string Email, required
        //FirstName string min:2, max:50, required
        //LastName string min:2, max:50, required
        //Password string min:1, required
        //RoleId int RoleFK, required
        //Enabled bool default:true, required
        //CreatedAt DateTime required

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.RoleId).IsRequired();
            builder.Property(u => u.Enabled).IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();
        }
    }
}