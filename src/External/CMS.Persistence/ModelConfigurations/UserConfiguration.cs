using CMS.Domain.Entities;
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
