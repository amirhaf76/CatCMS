using CMS.Domain.Entities;
using CMS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Persistence.ModelConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Id)
                .HasConversion(rId => rId.Value, id => RoleId.Create(id));

            builder
                .HasMany(r => r.Permissions)
                .WithMany();


        }
    }
}
