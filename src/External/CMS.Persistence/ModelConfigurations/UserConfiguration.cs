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
            builder.HasKey(u => u.Id);

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.Email)
                .HasConversion(u => u.Address, address => Email.CreateEmail(address))
                .HasMaxLength(150);

            builder
                .Property(u => u.Status)
                .HasConversion<string>()
                .HasMaxLength(150);

            builder
                .HasMany(u => u.Hosts)
                .WithOne(h => h.Creator)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
