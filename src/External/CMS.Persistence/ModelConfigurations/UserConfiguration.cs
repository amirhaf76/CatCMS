using CMS.Domain.Entities;
using CMS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder
                .Property(u => u.UserId)
                .HasConversion(id => id.Value, id => UserId.Create(id));

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.Email)
                .HasConversion(u => u.Address, address => Email.Create(address))
                .HasMaxLength(150);

            builder
                .Property(u => u.Status)
                .HasConversion<string>()
                .HasMaxLength(150);

            builder
                .HasMany(u => u.Hosts)
                .WithOne(h => h.Owner)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Permissions)
                .WithMany()
                .UsingEntity("UserPermissions");
                
        }
    }
}
